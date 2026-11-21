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
            formsPlot.Plot.Axes.Title.Label.FontSize = 16;

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

        // 1. SURVIVAL RATE PER COURSE (Graduated % + Exact Student Count by Program)
        private void LoadSurvivalRatePerCourseChart()
        {
            try
            {
                var programs = new List<string>();
                var rates = new List<double>();
                var gradCounts = new List<int>();
                var totalCounts = new List<int>();

                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            REPLACE(program, 'BS in ', '') AS course,
                            SUM(CASE WHEN academic_status = 'Graduated' THEN 1 ELSE 0 END) AS grad_count,
                            COUNT(*) AS total_count,
                            ROUND((SUM(CASE WHEN academic_status = 'Graduated' THEN 1 ELSE 0 END) / COUNT(*)) * 100, 1) AS survival_rate
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

                            prog = prog.Replace(" and Botanical Design", "")
                                       .Replace(" and Luxury Fashion Design", "");

                            programs.Add(prog);
                            int grad = reader["grad_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["grad_count"]);
                            int total = reader["total_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["total_count"]);
                            double rate = reader["survival_rate"] == DBNull.Value ? 0 : Convert.ToDouble(reader["survival_rate"]);

                            gradCounts.Add(grad);
                            totalCounts.Add(total);
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

                        // Ipakita sa ibabaw ng bawat bar ang percentage + exact count (hal. 29.2% (19/65))
                        bars.Bars[i].Label = $"{rates[i]:F1}% ({gradCounts[i]}/{totalCounts[i]})";
                    }

                    // Styling ng value labels sa ibabaw ng bars
                    bars.ValueLabelStyle.ForeColor = TextDarkPlum;
                    bars.ValueLabelStyle.FontSize = 11;
                    bars.ValueLabelStyle.Bold = true;

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

        // 2. STUDENT STATUS DISTRIBUTION (Pie Chart)
        private void LoadTransferRateChart()
        {
            formsPlotTransfer.Plot.Clear();

            var statusCounts = new Dictionary<string, int>();
            int totalStudents = 0;

            string query = @"
                SELECT academic_status, COUNT(*) AS total
                FROM students
                WHERE is_deleted = 0
                GROUP BY academic_status
                ORDER BY total DESC;";

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["academic_status"].ToString() ?? "Unknown";
                            int count = Convert.ToInt32(reader["total"]);
                            statusCounts[status] = count;
                            totalStudents += count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Student Status Distribution:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (totalStudents == 0)
            {
                formsPlotTransfer.Plot.Title("Student Status Distribution (No Data)");
                formsPlotTransfer.Refresh();
                return;
            }

            var sliceColors = new Dictionary<string, ScottPlot.Color>
            {
                { "Active",          ScottPlot.Color.FromHex("#89235B") },
                { "Graduated",       ScottPlot.Color.FromHex("#C2185B") },
                { "Transferred_In",  ScottPlot.Color.FromHex("#F10291") },
                { "Transferred_Out", ScottPlot.Color.FromHex("#F48FB1") },
                { "Dropped",         ScottPlot.Color.FromHex("#4A0E2E") }
            };

            var slices = new List<PieSlice>();

            foreach (var kvp in statusCounts)
            {
                double percentage = (double)kvp.Value / totalStudents * 100.0;
                string cleanName = kvp.Key.Replace("_", " ");

                var color = sliceColors.ContainsKey(kvp.Key)
                    ? sliceColors[kvp.Key]
                    : ScottPlot.Color.FromHex("#AD1457");

                var slice = new PieSlice
                {
                    Value = kvp.Value,
                    FillColor = color,
                    Label = $"{percentage:F1}%",
                    LegendText = $"{cleanName} ({kvp.Value} - {percentage:F1}%)"
                };

                slice.LabelFontColor = ScottPlot.Color.FromHex("#4A0E2E");
                slice.LabelFontSize = 14;
                slice.LabelBold = true;

                slices.Add(slice);
            }

            var pie = formsPlotTransfer.Plot.Add.Pie(slices);
            pie.ExplodeFraction = 0.04;
            pie.SliceLabelDistance = 1.25;

            formsPlotTransfer.Plot.Axes.Frameless();
            formsPlotTransfer.Plot.HideGrid();

            formsPlotTransfer.Plot.Title("Student Status Distribution (Transfer Rate)");
            formsPlotTransfer.Plot.Axes.Title.Label.ForeColor = ScottPlot.Color.FromHex("#4A0E2E");
            formsPlotTransfer.Plot.Axes.Title.Label.FontSize = 16;

            formsPlotTransfer.Plot.ShowLegend();
            formsPlotTransfer.Plot.Legend.Alignment = Alignment.LowerCenter;
            formsPlotTransfer.Plot.Legend.FontSize = 13;
            formsPlotTransfer.Plot.Legend.FontColor = ScottPlot.Color.FromHex("#4A0E2E");

            formsPlotTransfer.Plot.FigureBackground.Color = ScottPlot.Color.FromHex("#FFF3F2");
            formsPlotTransfer.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#FFF3F2");
            formsPlotTransfer.Plot.Benchmark.IsVisible = false;

            formsPlotTransfer.Plot.Axes.AutoScale();
            formsPlotTransfer.Refresh();
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

                    // color palette for lines
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
            MessageBox.Show("Charts refreshed with the latest database records!", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // single chart + status summary counts + student directory (grouped by status or enrollment year) as pdf
        private void ExportSingleChartToPdf(
            ScottPlot.WinForms.FormsPlot formsPlot,
            string reportTitle,
            string defaultFileName,
            string whereFilter = "is_deleted = 0",
            string groupBy = "none")
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

                                if (groupBy == "status")
                                {
                                    // NAKA-GROUP BY STATUS
                                    var groupedStudents = studentList
                                        .GroupBy(s => s.Status)
                                        .OrderBy(g => g.Key);

                                    foreach (var group in groupedStudents)
                                    {
                                        string cleanStatusName = group.Key.Replace("_", " ");

                                        col.Item().PaddingTop(6).Background("#FCE4EC").PaddingVertical(4).PaddingHorizontal(6)
                                            .Text($"{cleanStatusName} ({group.Count()})")
                                            .FontSize(10).Bold().FontColor("#89235B");

                                        col.Item().Table(table =>
                                        {
                                            table.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1.2f); // Student ID
                                                columns.RelativeColumn(2.3f); // Full Name
                                                columns.RelativeColumn(2.5f); // Program
                                                columns.RelativeColumn(1.1f); // Year Level
                                                columns.RelativeColumn(0.9f); // Batch
                                            });

                                            table.Header(header =>
                                            {
                                                header.Cell().PaddingBottom(3).Text("Student ID").Bold();
                                                header.Cell().PaddingBottom(3).Text("Full Name").Bold();
                                                header.Cell().PaddingBottom(3).Text("Program").Bold();
                                                header.Cell().PaddingBottom(3).Text("Year Level").Bold();
                                                header.Cell().PaddingBottom(3).Text("Batch").Bold();
                                            });

                                            foreach (var s in group.OrderBy(x => x.Id))
                                            {
                                                table.Cell().PaddingVertical(2).Text(s.Id);
                                                table.Cell().PaddingVertical(2).Text(s.FullName);
                                                table.Cell().PaddingVertical(2).Text(s.Program);
                                                table.Cell().PaddingVertical(2).Text(s.YearLevel);
                                                table.Cell().PaddingVertical(2).Text(s.EnrollmentYear);
                                            }
                                        });
                                    }
                                }
                                else if (groupBy == "year")
                                {
                                    // NAKA-GROUP BY ENROLLMENT YEAR
                                    var groupedByYear = studentList
                                        .GroupBy(s => s.EnrollmentYear)
                                        .OrderBy(g => g.Key);

                                    foreach (var group in groupedByYear)
                                    {
                                        col.Item().PaddingTop(6).Background("#FCE4EC").PaddingVertical(4).PaddingHorizontal(6)
                                            .Text($"Enrollment Year: {group.Key} ({group.Count()} Students)")
                                            .FontSize(10).Bold().FontColor("#89235B");

                                        col.Item().Table(table =>
                                        {
                                            table.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1.2f); // Student ID
                                                columns.RelativeColumn(2.2f); // Full Name
                                                columns.RelativeColumn(2.5f); // Program
                                                columns.RelativeColumn(1.1f); // Year Level
                                                columns.RelativeColumn(1.2f); // Status
                                            });

                                            table.Header(header =>
                                            {
                                                header.Cell().PaddingBottom(3).Text("Student ID").Bold();
                                                header.Cell().PaddingBottom(3).Text("Full Name").Bold();
                                                header.Cell().PaddingBottom(3).Text("Program").Bold();
                                                header.Cell().PaddingBottom(3).Text("Year Level").Bold();
                                                header.Cell().PaddingBottom(3).Text("Status").Bold();
                                            });

                                            foreach (var s in group.OrderBy(x => x.Id))
                                            {
                                                table.Cell().PaddingVertical(2).Text(s.Id);
                                                table.Cell().PaddingVertical(2).Text(s.FullName);
                                                table.Cell().PaddingVertical(2).Text(s.Program);
                                                table.Cell().PaddingVertical(2).Text(s.YearLevel);
                                                table.Cell().PaddingVertical(2).Text(s.Status.Replace("_", " "));
                                            }
                                        });
                                    }
                                }
                                else
                                {
                                    // STANDARD SINGLE DIRECTORY TABLE
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

                                        foreach (var s in studentList.OrderBy(x => x.Id))
                                        {
                                            table.Cell().PaddingVertical(2).Text(s.Id);
                                            table.Cell().PaddingVertical(2).Text(s.FullName);
                                            table.Cell().PaddingVertical(2).Text(s.Program);
                                            table.Cell().PaddingVertical(2).Text(s.YearLevel);
                                            table.Cell().PaddingVertical(2).Text(s.EnrollmentYear);
                                            table.Cell().PaddingVertical(2).Text(s.Status);
                                        }
                                    });
                                }
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

        // 1. Export Survival Rate Report (PDF - Naka-group by Status)
        private void btnExportSurvival_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotSurvival,
                "Survival Rate per Course Report",
                "SurvivalRate_Report",
                "is_deleted = 0",
                groupBy: "status"
            );
        }

        // 2. Export Transfer Rate Report (PDF - Naka-group sa Transferred_In at Transferred_Out students)
        private void btnExportTransfer_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotTransfer,
                "Student Status Distribution Report (Transfers Breakdown)",
                "TransferRate_Report",
                "is_deleted = 0 AND academic_status IN ('Transferred_In', 'Transferred_Out')",
                groupBy: "status"
            );
        }

        // 3. Export Enrollment Trend Report (PDF - Naka-group per Enrollment Year)
        private void btnExportEnrollment_Click(object? sender, EventArgs e)
        {
            ExportSingleChartToPdf(
                formsPlotEnrollment,
                "Enrollment Count per Year (by Program) Report",
                "EnrollmentTrend_Report",
                "is_deleted = 0",
                groupBy: "year"
            );
        }
    }
}