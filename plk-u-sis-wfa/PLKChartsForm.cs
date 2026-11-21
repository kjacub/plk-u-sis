using MySql.Data.MySqlClient;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;

namespace plk_u_sis_wfa
{
    public partial class PLKChartsForm : Form
    {
        // Theme Colors
        private readonly ScottPlot.Color LightPink = new ScottPlot.Color(255, 202, 228);
        private readonly ScottPlot.Color DeepPlum = new ScottPlot.Color(137, 35, 91);
        private readonly ScottPlot.Color TextDarkPlum = ScottPlot.Color.FromHex("#4A0E2E");

        public PLKChartsForm()
        {
            InitializeComponent();
            this.Load += PLKChartsForm_Load;

            btnRefresh.Click += btnRefresh_Click;
            btnBack.Click += btnBack_Click;
            btnExportSurvival.Click += btnExportSurvival_Click;
            btnExportTransfer.Click += btnExportTransfer_Click;
            btnExportEnrollment.Click += btnExportEnrollment_Click;

        }

        private void PLKChartsForm_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefreshAllCharts();
        }

        private void RefreshAllCharts()
        {
            LoadSurvivalRatePerCourseChart();
            LoadTransferRateChart();
            LoadEnrollmentPerYearPerProgramChart();
        }

        // Helper para i-apply ang consistent text color at itago ang FPS benchmark box
        private void ApplyChartTextStyling(ScottPlot.WinForms.FormsPlot formsPlot, string title, string yLabel, string xLabel = "")
        {
            formsPlot.Plot.Benchmark.IsVisible = false;

            formsPlot.Plot.Title(title);
            formsPlot.Plot.Axes.Title.Label.ForeColor = TextDarkPlum;
            formsPlot.Plot.Axes.Title.Label.FontSize = 13;

            formsPlot.Plot.YLabel(yLabel);
            formsPlot.Plot.Axes.Left.Label.ForeColor = TextDarkPlum;
            formsPlot.Plot.Axes.Left.TickLabelStyle.ForeColor = TextDarkPlum;

            if (!string.IsNullOrEmpty(xLabel))
            {
                formsPlot.Plot.XLabel(xLabel);
                formsPlot.Plot.Axes.Bottom.Label.ForeColor = TextDarkPlum;
            }
            formsPlot.Plot.Axes.Bottom.TickLabelStyle.ForeColor = TextDarkPlum;
        }

        // 1. SURVIVAL RATE PER COURSE (Graduated % by Program)
        private void LoadSurvivalRatePerCourseChart()
        {
            try
            {
                var programs = new List<string>();
                var rates = new List<double>();

                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            REPLACE(program, 'BS in ', '') AS course,
                            ROUND((SUM(CASE WHEN academic_status = 'Graduated' THEN 1 ELSE 0 END) / COUNT(*)) * 100, 2) AS survival_rate
                        FROM students
                        WHERE is_deleted = 0
                        GROUP BY program
                        ORDER BY survival_rate DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prog = reader["course"].ToString() ?? "Unknown";
                            // Paikliin ang mahahabang labels para hindi magpatong sa X-axis
                            prog = prog.Replace(" and Botanical Design", "")
                                       .Replace(" and Luxury Fashion Design", "");

                            programs.Add(prog);
                            double rate = reader["survival_rate"] == DBNull.Value ? 0 : Convert.ToDouble(reader["survival_rate"]);
                            rates.Add(rate);
                        }
                    }
                }

                formsPlotSurvival.Plot.Clear();

                if (rates.Count > 0)
                {
                    var bars = formsPlotSurvival.Plot.Add.Bars(rates.ToArray());

                    for (int i = 0; i < bars.Bars.Count; i++)
                    {
                        bars.Bars[i].FillColor = (i % 2 == 0) ? DeepPlum : LightPink;
                        bars.Bars[i].LineColor = DeepPlum;
                    }

                    Tick[] ticks = new Tick[programs.Count];
                    for (int i = 0; i < programs.Count; i++)
                    {
                        ticks[i] = new Tick(i, programs[i]);
                    }
                    formsPlotSurvival.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                    formsPlotSurvival.Plot.Axes.Bottom.TickLabelStyle.Rotation = -20;
                    formsPlotSurvival.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    formsPlotSurvival.Plot.Axes.Bottom.MinimumSize = 55;
                    formsPlotSurvival.Plot.Axes.SetLimitsY(0, 105);
                }

                ApplyChartTextStyling(formsPlotSurvival, "Survival Rate per Course (Graduated %)", "Survival Rate (%)");
                formsPlotSurvival.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Survival Rate chart:\n" + ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. TRANSFER RATE (Transferred_In vs. Transferred_Out %)
        private void LoadTransferRateChart()
        {
            try
            {
                var categories = new List<string>();
                var rates = new List<double>();

                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            'Transferred In' AS transfer_type,
                            ROUND((SUM(CASE WHEN academic_status = 'Transferred_In' THEN 1 ELSE 0 END) / COUNT(*)) * 100, 2) AS rate
                        FROM students
                        WHERE is_deleted = 0

                        UNION ALL

                        SELECT 
                            'Transferred Out' AS transfer_type,
                            ROUND((SUM(CASE WHEN academic_status = 'Transferred_Out' THEN 1 ELSE 0 END) / COUNT(*)) * 100, 2) AS rate
                        FROM students
                        WHERE is_deleted = 0";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["transfer_type"].ToString() ?? "");
                            double rate = reader["rate"] == DBNull.Value ? 0 : Convert.ToDouble(reader["rate"]);
                            rates.Add(rate);
                        }
                    }
                }

                formsPlotTransfer.Plot.Clear();

                if (rates.Count > 0)
                {
                    var bars = formsPlotTransfer.Plot.Add.Bars(rates.ToArray());
                    if (bars.Bars.Count >= 2)
                    {
                        bars.Bars[0].FillColor = DeepPlum;  // Transferred In
                        bars.Bars[0].LineColor = DeepPlum;

                        bars.Bars[1].FillColor = LightPink; // Transferred Out
                        bars.Bars[1].LineColor = DeepPlum;
                    }

                    Tick[] ticks = new Tick[categories.Count];
                    for (int i = 0; i < categories.Count; i++)
                    {
                        ticks[i] = new Tick(i, categories[i]);
                    }
                    formsPlotTransfer.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                    formsPlotTransfer.Plot.Axes.SetLimitsY(0, 105);
                }

                ApplyChartTextStyling(formsPlotTransfer, "Student Transfer Rate (In vs. Out %)", "Transfer Rate (%)");
                formsPlotTransfer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Transfer Rate chart:\n" + ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. ENROLLMENT COUNT PER YEAR (PER PROGRAM) - Multi-Line Chart
        private void LoadEnrollmentPerYearPerProgramChart()
        {
            try
            {
                var rawData = new List<(int Year, string Program, int Count)>();

                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            enrollment_year,
                            REPLACE(program, 'BS in ', '') AS course,
                            COUNT(*) AS total
                        FROM students
                        WHERE is_deleted = 0
                        GROUP BY enrollment_year, program
                        ORDER BY enrollment_year ASC";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int yr = Convert.ToInt32(reader["enrollment_year"]);
                            string prog = reader["course"].ToString() ?? "Unknown";
                            int cnt = Convert.ToInt32(reader["total"]);
                            rawData.Add((yr, prog, cnt));
                        }
                    }
                }

                formsPlotEnrollment.Plot.Clear();

                if (rawData.Count > 0)
                {
                    var distinctYears = rawData.Select(d => d.Year).Distinct().OrderBy(y => y).ToList();
                    var distinctPrograms = rawData.Select(d => d.Program).Distinct().OrderBy(p => p).ToList();

                    double[] xPositions = Enumerable.Range(0, distinctYears.Count).Select(i => (double)i).ToArray();

                    // Plum/Rose palette para sa 4 lines
                    ScottPlot.Color[] lineColors = new ScottPlot.Color[]
                    {
                        DeepPlum,
                        ScottPlot.Color.FromHex("#D81B60"),
                        ScottPlot.Color.FromHex("#8E24AA"),
                        ScottPlot.Color.FromHex("#F06292")
                    };

                    for (int pIndex = 0; pIndex < distinctPrograms.Count; pIndex++)
                    {
                        string prog = distinctPrograms[pIndex];
                        double[] yCounts = new double[distinctYears.Count];

                        for (int i = 0; i < distinctYears.Count; i++)
                        {
                            int yr = distinctYears[i];
                            var match = rawData.FirstOrDefault(d => d.Year == yr && d.Program == prog);
                            yCounts[i] = match.Count;
                        }

                        var scatter = formsPlotEnrollment.Plot.Add.Scatter(xPositions, yCounts);
                        scatter.LegendText = prog;
                        scatter.Color = lineColors[pIndex % lineColors.Length];
                        scatter.LineWidth = 2.5f;
                        scatter.MarkerSize = 7;
                    }

                    Tick[] ticks = new Tick[distinctYears.Count];
                    for (int i = 0; i < distinctYears.Count; i++)
                    {
                        ticks[i] = new Tick(i, distinctYears[i].ToString());
                    }
                    formsPlotEnrollment.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

                    // Ilagay sa UpperRight para hindi matakpan ang points sa 2023
                    formsPlotEnrollment.Plot.ShowLegend(Alignment.UpperRight);
                    formsPlotEnrollment.Plot.Legend.FontColor = TextDarkPlum;
                    formsPlotEnrollment.Plot.Legend.BackgroundColor = ScottPlot.Color.FromHex("#FCE4EC");

                    formsPlotEnrollment.Plot.Axes.Margins(bottom: 0.1, top: 0.25);
                }

                ApplyChartTextStyling(formsPlotEnrollment, "Enrollment Count per Year (by Program)", "Enrolled Students", "Enrollment Year");
                formsPlotEnrollment.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Enrollment chart:\n" + ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            RefreshAllCharts();
            MessageBox.Show("Dashboard charts refreshed with the latest database records!", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Reusable helper para i-export ang isang chart bilang PNG image
        private void ExportSingleChart(ScottPlot.WinForms.FormsPlot formsPlot, string defaultFileName, int width = 1000, int height = 600)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png";
                sfd.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        formsPlot.Plot.SavePng(sfd.FileName, width, height);
                        MessageBox.Show("Chart exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting chart:\n" + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Reusable helper para mag-export ng single chart + status summary counts + student directory bilang PDF
        private void ExportSingleChartToPdf(
            ScottPlot.WinForms.FormsPlot formsPlot,
            string reportTitle,
            string defaultFileName,
            string whereFilter = "is_deleted = 0")
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Document (*.pdf)|*.pdf";
                sfd.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    QuestPDF.Settings.License = LicenseType.Community;

                    // 1. Kunin ang image bytes ng napiling ScottPlot chart
                    byte[] chartImageBytes = formsPlot.Plot.GetImageBytes(900, 480, ScottPlot.ImageFormat.Png);

                    // 2. Kunin ang overall status counts mula sa MySQL (para sa summary box)
                    int totalStudents = 0, activeCount = 0, graduatedCount = 0, tiCount = 0, toCount = 0, droppedCount = 0;

                    var studentList = new List<(string Id, string FullName, string Program, string YearLevel, string EnrollmentYear, string Status)>();

                    using (var conn = DBConnection.GetConnection())
                    {
                        conn.Open();

                        // Query A: Overall Status Counts
                        string countQuery = @"
                    SELECT 
                        COUNT(*) AS total,
                        SUM(CASE WHEN academic_status = 'Active' THEN 1 ELSE 0 END) AS active_cnt,
                        SUM(CASE WHEN academic_status = 'Graduated' THEN 1 ELSE 0 END) AS grad_cnt,
                        SUM(CASE WHEN academic_status = 'Transferred_In' THEN 1 ELSE 0 END) AS ti_cnt,
                        SUM(CASE WHEN academic_status = 'Transferred_Out' THEN 1 ELSE 0 END) AS to_cnt,
                        SUM(CASE WHEN academic_status = 'Dropped' THEN 1 ELSE 0 END) AS drop_cnt
                    FROM students
                    WHERE is_deleted = 0";

                        using (var countCmd = new MySqlCommand(countQuery, conn))
                        using (var countReader = countCmd.ExecuteReader())
                        {
                            if (countReader.Read())
                            {
                                totalStudents = countReader["total"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["total"]);
                                activeCount = countReader["active_cnt"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["active_cnt"]);
                                graduatedCount = countReader["grad_cnt"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["grad_cnt"]);
                                tiCount = countReader["ti_cnt"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["ti_cnt"]);
                                toCount = countReader["to_cnt"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["to_cnt"]);
                                droppedCount = countReader["drop_cnt"] == DBNull.Value ? 0 : Convert.ToInt32(countReader["drop_cnt"]);
                            }
                        }

                        // Query B: Student Directory Table
                        string query = $@"
                    SELECT student_id, 
                           CONCAT_WS(' ', first_name, middle_name, last_name) AS full_name, 
                           program, 
                           year_level,
                           enrollment_year,
                           academic_status 
                    FROM students 
                    WHERE {whereFilter} 
                    ORDER BY student_id ASC";

                        using (var cmd = new MySqlCommand(query, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                studentList.Add((
                                    reader["student_id"].ToString() ?? "",
                                    reader["full_name"].ToString() ?? "",
                                    reader["program"].ToString() ?? "",
                                    reader["year_level"].ToString() ?? "",
                                    reader["enrollment_year"].ToString() ?? "",
                                    reader["academic_status"].ToString() ?? ""
                                ));
                            }
                        }
                    }

                    // 3. I-generate ang PDF
                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(35);
                            page.PageColor(QuestPDF.Helpers.Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(9.5f).FontFamily("Lato"));

                            // HEADER
                            page.Header().PaddingBottom(8).Column(col =>
                            {
                                col.Item().Text(reportTitle)
                                    .FontSize(16).Bold().FontColor("#89235B");

                                col.Item().Text($"Generated Date: {DateTime.Now:MMMM dd, yyyy}")
                                    .FontSize(10).FontColor(QuestPDF.Helpers.Colors.Grey.Darken2);
                            });

                            // CONTENT (Summary Counts + Chart + Table)
                            page.Content().Column(col =>
                            {
                                col.Spacing(10);

                                // SUMMARY COUNTS BOX (Total, Active, Graduated, TI, TO, Dropped)
                                col.Item().Background("#FCE4EC").Border(1).BorderColor("#89235B").Padding(8).Row(row =>
                                {
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Total Records").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(totalStudents.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Active").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(activeCount.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Graduated").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(graduatedCount.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Transferred In").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(tiCount.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Transferred Out").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(toCount.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                    row.RelativeItem().AlignCenter().Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Dropped").FontSize(8).FontColor("#4A0E2E");
                                        c.Item().AlignCenter().Text(droppedCount.ToString()).FontSize(12).Bold().FontColor("#89235B");
                                    });
                                });

                                // Chart Image
                                col.Item().Image(chartImageBytes).FitWidth();

                                // Table Title
                                col.Item().PaddingTop(4).Text($"Student Records Breakdown ({studentList.Count} Listed)")
                                    .FontSize(11).Bold().FontColor("#4A0E2E");

                                // Directory Table
                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1.2f); // Student ID
                                        columns.RelativeColumn(2.1f); // Full Name
                                        columns.RelativeColumn(2.4f); // Program
                                        columns.RelativeColumn(1.1f); // Year Level
                                        columns.RelativeColumn(0.9f); // Batch
                                        columns.RelativeColumn(1.2f); // Status
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().PaddingBottom(4).Text("Student ID").Bold();
                                        header.Cell().PaddingBottom(4).Text("Full Name").Bold();
                                        header.Cell().PaddingBottom(4).Text("Program").Bold();
                                        header.Cell().PaddingBottom(4).Text("Year Level").Bold();
                                        header.Cell().PaddingBottom(4).Text("Batch").Bold();
                                        header.Cell().PaddingBottom(4).Text("Status").Bold();
                                    });

                                    foreach (var s in studentList)
                                    {
                                        table.Cell().PaddingVertical(2).Text(s.Id);
                                        table.Cell().PaddingVertical(2).Text(s.FullName);
                                        table.Cell().PaddingVertical(2).Text(s.Program);
                                        table.Cell().PaddingVertical(2).Text(s.YearLevel);
                                        table.Cell().PaddingVertical(2).Text(s.EnrollmentYear);
                                        table.Cell().PaddingVertical(2).Text(s.Status);
                                    }
                                });
                            });

                            // FOOTER (Page X / Y)
                            page.Footer().AlignCenter().Text(x =>
                            {
                                x.CurrentPageNumber();
                                x.Span(" / ");
                                x.TotalPages();
                            });
                        });
                    })
                    .GeneratePdf(sfd.FileName);

                    MessageBox.Show("PDF Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating PDF:\n" + ex.Message, "PDF Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 1. Export Survival Rate Report (PDF)
        private void btnExportSurvival_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotSurvival,
                "Survival Rate per Course Report",
                "SurvivalRate_Report",
                "is_deleted = 0"
            );
        }

        // 2. Export Transfer Rate Report (PDF - naka-filter sa Transferred_In at Transferred_Out students)
        private void btnExportTransfer_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotTransfer,
                "Student Transfer Rate Report (In vs. Out)",
                "TransferRate_Report",
                "is_deleted = 0 AND academic_status IN ('Transferred_In', 'Transferred_Out')"
            );
        }

        // 3. Export Enrollment Trend Report (PDF)
        private void btnExportEnrollment_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotEnrollment,
                "Enrollment Count per Year (by Program) Report",
                "EnrollmentTrend_Report",
                "is_deleted = 0"
            );
        }
    }
}