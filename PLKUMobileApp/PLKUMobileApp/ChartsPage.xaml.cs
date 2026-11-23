using System.Text;
using MySqlConnector;

namespace PLKUMobileApp
{
    public partial class ChartsPage : ContentPage
    {
        private async Task<string> GetConnectionStringAsync()
        {
            string pwd = await DatabaseConfig.GetPasswordAsync();

            return new MySqlConnectionStringBuilder
            {
                Server = "10.0.2.2",
                Port = 3306,
                Database = "plk_u_sis_db",
                UserID = "capstone_user",
                Password = pwd,
                ConnectionTimeout = 10
            }.ConnectionString;
        }

        private readonly string[] _years = ["2023", "2024", "2025", "2026"];
        private readonly (string FullName, string ShortName, Color Color)[] _programs =
        [
            ("BS in Cosmetic Science", "Cosmetic Science", Color.FromArgb("#69143E")),
            ("BS in Floriculture and Botanical Design", "Floriculture", Color.FromArgb("#E91E63")),
            ("BS in Haute Couture and Luxury Fashion Design", "Haute Couture", Color.FromArgb("#9C27B0")),
            ("BS in Historical Fashion", "Historical Fashion", Color.FromArgb("#FF80AB"))
        ];

        private readonly Dictionary<string, Color> _statusColors = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Active"] = Color.FromArgb("#E91E63"),
            ["Graduated"] = Color.FromArgb("#7B1FA2"),
            ["Dropped"] = Color.FromArgb("#FF80AB"),
            ["Transferred Out"] = Color.FromArgb("#F50057"),
            ["Transferred In"] = Color.FromArgb("#BA68C8")
        };

        private Dictionary<string, int[]> _enrollmentByProgram = new();
        private record struct SurvivalStat(int Graduated, int Total);
        private Dictionary<string, SurvivalStat> _survivalByProgram = new();
        private Dictionary<string, int> _statusCounts = new();
        private int _totalStudents;

        private readonly EnrollmentLineDrawable _enrollmentDrawable = new();
        private readonly SurvivalBarDrawable _survivalDrawable = new();
        private readonly StatusPieDrawable _statusPieDrawable = new();

        public ChartsPage()
        {
            InitializeComponent();
            gvEnrollmentChart.Drawable = _enrollmentDrawable;
            gvSurvivalChart.Drawable = _survivalDrawable;
            gvStatusPieChart.Drawable = _statusPieDrawable;
            ApplyTheme(ThemeManager.IsDarkMode);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ThemeManager.ThemeChanged += ApplyTheme;
            ApplyTheme(ThemeManager.IsDarkMode);
            await LoadAllChartDataAsync(showConfirmation: false);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ThemeManager.ThemeChanged -= ApplyTheme;
        }

        public void OnToggleDarkModeClicked(object? sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private void ApplyTheme(bool isDark)
        {
            BackgroundColor = isDark ? Color.FromArgb("#1A0B14") : Color.FromArgb("#B85D85");

            Color cardBg = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#FCEEF2");
            Color cardStroke = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#7A1C4B");
            Color headingColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");
            Color subColor = isDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#7A2850");
            Color exportBtnBg = isDark ? Color.FromArgb("#3B192D") : Color.FromArgb("#F8D7E4");
            Color exportBtnText = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");

            Border[] cards = [cardHeader, cardEnrollmentChart, cardSurvivalChart, cardStatusChart, cardActions];
            foreach (var c in cards)
            {
                if (c != null)
                {
                    c.BackgroundColor = cardBg;
                    c.Stroke = cardStroke;
                }
            }

            lblChartsTitle.TextColor = headingColor;
            lblChartsSubtitle.TextColor = subColor;
            lblEnrollmentTitle.TextColor = headingColor;
            lblSurvivalTitle.TextColor = headingColor;
            lblStatusTitle.TextColor = headingColor;
            lblFooter.TextColor = isDark ? Color.FromArgb("#D8A8BE") : Color.FromArgb("#FCEEF2");

            Button[] exportButtons = [btnExportEnrollment, btnExportSurvival, btnExportTransfer];
            foreach (var btn in exportButtons)
            {
                if (btn != null)
                {
                    btn.BackgroundColor = exportBtnBg;
                    btn.BorderColor = cardStroke;
                    btn.TextColor = exportBtnText;
                }
            }

            btnDarkMode.Text = isDark ? "☀️ Light" : "🌙 Dark";
            btnDarkMode.BackgroundColor = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#69143E");
            btnDarkMode.TextColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderColor = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderWidth = 1;

            _enrollmentDrawable.IsDark = isDark;
            _survivalDrawable.IsDark = isDark;
            _statusPieDrawable.IsDark = isDark;

            gvEnrollmentChart.Invalidate();
            gvSurvivalChart.Invalidate();
            gvStatusPieChart.Invalidate();
            RenderLegends(isDark);
        }

        public async void OnRefreshChartsClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync(
                "Refresh Charts",
                "Reload latest enrollment, survival rate, and status distribution data from the database?",
                "Yes, Refresh",
                "Cancel");

            if (!confirm) return;

            await LoadAllChartDataAsync(showConfirmation: true);
        }

        public async void OnBackToDashboardClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync(
                "Back to Dashboard",
                "Return to the Dashboard?",
                "Yes",
                "Cancel");

            if (!confirm) return;

            await Shell.Current.GoToAsync("..");
        }

        public async void OnExportEnrollmentClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync(
                "Export Enrollment Rate Chart",
                "Generate and export PDF report for Enrollment Count per Year (by Program)?",
                "Yes, Export",
                "Cancel");

            if (!confirm) return;

            await LoadAllChartDataAsync(showConfirmation: false);

            var lines = new List<string>
            {
                "PLK UNIVERSITY - STUDENT INFORMATION SYSTEM",
                "REPORT: ENROLLMENT COUNT PER YEAR (BY PROGRAM)",
                $"Generated: {DateTime.Now:yyyy-MM-dd hh:mm:ss tt}",
                $"Total Active Records: {_totalStudents}",
                "============================================================"
            };

            foreach (var prog in _programs)
            {
                int[] counts = _enrollmentByProgram.GetValueOrDefault(prog.FullName, new int[_years.Length]);
                int progTotal = counts.Sum();
                string yearBreakdown = string.Join("   |   ", _years.Select((y, idx) => $"{y}: {counts[idx]}"));
                lines.Add($"{prog.ShortName} (Total: {progTotal})");
                lines.Add($"   {yearBreakdown}");
                lines.Add("");
            }

            await ExportPdfAndShareAsync("PLKU_Enrollment_Rate_Report.pdf", "Enrollment Rate Report", lines);
        }

        public async void OnExportSurvivalClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync(
                "Export Survival Rate Chart",
                "Generate and export PDF report for Survival Rate per Course (Graduated %)?",
                "Yes, Export",
                "Cancel");

            if (!confirm) return;

            await LoadAllChartDataAsync(showConfirmation: false);

            var lines = new List<string>
            {
                "PLK UNIVERSITY - STUDENT INFORMATION SYSTEM",
                "REPORT: SURVIVAL RATE PER COURSE (GRADUATED %)",
                $"Generated: {DateTime.Now:yyyy-MM-dd hh:mm:ss tt}",
                "============================================================"
            };

            foreach (var prog in _programs)
            {
                var stat = _survivalByProgram.GetValueOrDefault(prog.FullName, new SurvivalStat(0, 0));
                double rate = stat.Total > 0 ? (stat.Graduated * 100.0) / stat.Total : 0.0;
                lines.Add($"{prog.ShortName}: {rate:0.0}% ({stat.Graduated} Graduated / {stat.Total} Students)");
            }

            await ExportPdfAndShareAsync("PLKU_Survival_Rate_Report.pdf", "Survival Rate Report", lines);
        }

        public async void OnExportTransferClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync(
                "Export Transfer Rate Chart",
                "Generate and export PDF report for Student Status Distribution (Transfer Rate)?",
                "Yes, Export",
                "Cancel");

            if (!confirm) return;

            await LoadAllChartDataAsync(showConfirmation: false);

            var lines = new List<string>
            {
                "PLK UNIVERSITY - STUDENT INFORMATION SYSTEM",
                "REPORT: STUDENT STATUS DISTRIBUTION (TRANSFER RATE)",
                $"Generated: {DateTime.Now:yyyy-MM-dd hh:mm:ss tt}",
                $"Total Students: {_totalStudents}",
                "============================================================"
            };

            foreach (var kvp in _statusCounts)
            {
                double pct = _totalStudents > 0 ? (kvp.Value * 100.0) / _totalStudents : 0.0;
                lines.Add($"{kvp.Key}: {kvp.Value} students ({pct:0.0}%)");
            }

            await ExportPdfAndShareAsync("PLKU_Transfer_Rate_Report.pdf", "Transfer Rate Report", lines);
        }

        private async Task ExportPdfAndShareAsync(string fileName, string chartName, List<string> lines)
        {
            try
            {
                byte[] pdfBytes = BuildSimplePdfBytes(lines);
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
                await File.WriteAllBytesAsync(filePath, pdfBytes);

                await Share.Default.RequestAsync(new ShareFileRequest
                {
                    Title = $"Export {chartName}",
                    File = new ShareFile(filePath, "application/pdf")
                });
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Export Error", $"Failed to export PDF: {ex.Message}", "OK");
            }
        }

        private static byte[] BuildSimplePdfBytes(List<string> lines)
        {
            static string EscapePdfText(string input) =>
                input.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)");

            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("BT");
            contentBuilder.AppendLine("/F1 11 Tf");
            contentBuilder.AppendLine("45 745 Td");
            contentBuilder.AppendLine("16 TL");

            for (int i = 0; i < lines.Count; i++)
            {
                string escaped = EscapePdfText(lines[i]);
                if (i == 0)
                    contentBuilder.AppendLine($"({escaped}) Tj");
                else
                    contentBuilder.AppendLine($"T* ({escaped}) Tj");
            }

            contentBuilder.AppendLine("ET");
            string streamContent = contentBuilder.ToString();
            int streamLength = Encoding.ASCII.GetByteCount(streamContent);

            var pdf = new StringBuilder();
            var offsets = new List<int> { 0 };

            void AppendObj(string objText)
            {
                offsets.Add(Encoding.ASCII.GetByteCount(pdf.ToString()));
                pdf.Append(objText);
            }

            pdf.AppendLine("%PDF-1.4");
            AppendObj("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");
            AppendObj("2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n");
            AppendObj("3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>\nendobj\n");
            AppendObj("4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n");
            AppendObj($"5 0 obj\n<< /Length {streamLength} >>\nstream\n{streamContent}endstream\nendobj\n");

            int xrefStart = Encoding.ASCII.GetByteCount(pdf.ToString());
            pdf.AppendLine($"xref\n0 {offsets.Count}");
            pdf.AppendLine("0000000000 65535 f ");
            for (int i = 1; i < offsets.Count; i++)
            {
                pdf.AppendLine($"{offsets[i]:D10} 00000 n ");
            }
            pdf.AppendLine($"trailer\n<< /Size {offsets.Count} /Root 1 0 R >>\nstartxref\n{xrefStart}\n%%EOF");

            return Encoding.ASCII.GetBytes(pdf.ToString());
        }

        private async Task LoadAllChartDataAsync(bool showConfirmation)
        {
            _enrollmentByProgram = _programs.ToDictionary(
                p => p.FullName,
                _ => new int[_years.Length],
                StringComparer.OrdinalIgnoreCase);

            _survivalByProgram = _programs.ToDictionary(
                p => p.FullName,
                _ => new SurvivalStat(0, 0),
                StringComparer.OrdinalIgnoreCase);

            _statusCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                ["Active"] = 0,
                ["Graduated"] = 0,
                ["Dropped"] = 0,
                ["Transferred Out"] = 0,
                ["Transferred In"] = 0
            };

            _totalStudents = 0;

            try
            {
                using var conn = new MySqlConnection(await GetConnectionStringAsync()); await conn.OpenAsync();

                string checkColSql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
                                       WHERE TABLE_SCHEMA = 'plk_u_sis_db' 
                                         AND TABLE_NAME = 'students' 
                                         AND COLUMN_NAME = 'is_deleted'";
                using var checkCmd = new MySqlCommand(checkColSql, conn);
                bool hasIsDeleted = Convert.ToInt32(await checkCmd.ExecuteScalarAsync()) > 0;

                string sql = hasIsDeleted
                    ? "SELECT program, enrollment_year, academic_status FROM students WHERE is_deleted = 0"
                    : "SELECT program, enrollment_year, academic_status FROM students";

                using var cmd = new MySqlCommand(sql, conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    _totalStudents++;
                    string program = reader["program"]?.ToString()?.Trim() ?? "";
                    string enrollYear = reader["enrollment_year"]?.ToString()?.Trim() ?? "";
                    string rawStatus = reader["academic_status"]?.ToString()?.Trim() ?? "";

                    string normalizedStatus = rawStatus.Replace("_", " ");
                    if (normalizedStatus.Equals("Enrolled", StringComparison.OrdinalIgnoreCase))
                        normalizedStatus = "Active";

                    if (!string.IsNullOrEmpty(normalizedStatus))
                    {
                        _statusCounts[normalizedStatus] = _statusCounts.GetValueOrDefault(normalizedStatus) + 1;
                    }

                    if (!string.IsNullOrEmpty(program))
                    {
                        if (_enrollmentByProgram.TryGetValue(program, out var yearArr))
                        {
                            int yearIdx = Array.IndexOf(_years, enrollYear);
                            if (yearIdx >= 0)
                                yearArr[yearIdx]++;
                        }

                        if (_survivalByProgram.TryGetValue(program, out var surv))
                        {
                            int gradInc = normalizedStatus.Equals("Graduated", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                            _survivalByProgram[program] = new SurvivalStat(surv.Graduated + gradInc, surv.Total + 1);
                        }
                    }
                }

                if (showConfirmation)
                {
                    await DisplayAlertAsync("Refreshed", $"Charts synced ({_totalStudents} students).", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Connection Error", ex.Message, "OK");
            }
            finally
            {
                _enrollmentDrawable.Years = _years;
                _enrollmentDrawable.Series = _programs
                    .Select(p => (p.ShortName, _enrollmentByProgram.GetValueOrDefault(p.FullName, new int[_years.Length]), p.Color))
                    .ToList();

                _survivalDrawable.Bars = _programs
                    .Select(p =>
                    {
                        var s = _survivalByProgram.GetValueOrDefault(p.FullName, new SurvivalStat(0, 0));
                        double pct = s.Total > 0 ? (s.Graduated * 100.0) / s.Total : 0.0;
                        return (p.ShortName, pct, s.Graduated, s.Total, p.Color);
                    })
                    .ToList();

                _statusPieDrawable.Slices = _statusCounts
                    .Select(kvp => (
                        kvp.Key,
                        kvp.Value,
                        _statusColors.TryGetValue(kvp.Key, out var col) ? col : Color.FromArgb("#EC407A")
                    ))
                    .ToList();

                gvEnrollmentChart.Invalidate();
                gvSurvivalChart.Invalidate();
                gvStatusPieChart.Invalidate();
                RenderLegends(ThemeManager.IsDarkMode);
            }
        }

        private void RenderLegends(bool isDark)
        {
            Color textColor = isDark ? Color.FromArgb("#FFE4EE") : Color.FromArgb("#3B0D24");

            survivalSummaryContainer.Clear();
            foreach (var p in _programs)
            {
                var s = _survivalByProgram.GetValueOrDefault(p.FullName, new SurvivalStat(0, 0));
                double rate = s.Total > 0 ? (s.Graduated * 100.0) / s.Total : 0.0;
                survivalSummaryContainer.Children.Add(new Label
                {
                    Text = $"▪ {p.ShortName}: {rate:0.0}% ({s.Graduated}/{s.Total})",
                    FontSize = 11.5,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = textColor
                });
            }

            statusLegendContainer.Clear();
            foreach (var kvp in _statusCounts)
            {
                double pct = _totalStudents > 0 ? (kvp.Value * 100.0) / _totalStudents : 0.0;
                Color dotColor = _statusColors.TryGetValue(kvp.Key, out var c) ? c : Colors.Pink;

                var row = new HorizontalStackLayout { Spacing = 8 };
                row.Children.Add(new BoxView
                {
                    Color = dotColor,
                    WidthRequest = 12,
                    HeightRequest = 12,
                    CornerRadius = 6,
                    VerticalOptions = LayoutOptions.Center
                });
                row.Children.Add(new Label
                {
                    Text = $"{kvp.Key}: {kvp.Value} ({pct:0.0}%)",
                    FontSize = 11.5,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = textColor,
                    VerticalOptions = LayoutOptions.Center
                });
                statusLegendContainer.Children.Add(row);
            }
        }

        private sealed class EnrollmentLineDrawable : IDrawable
        {
            public bool IsDark { get; set; }
            public string[] Years { get; set; } = ["2023", "2024", "2025", "2026"];
            public List<(string Name, int[] Counts, Color Color)> Series { get; set; } = [];

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.FillColor = IsDark ? Color.FromArgb("#180A12") : Colors.White;
                canvas.FillRectangle(dirtyRect);

                if (Series.Count == 0 || Years.Length == 0) return;

                float left = 34f, right = dirtyRect.Width - 16f, top = 16f, bottom = dirtyRect.Height - 28f;
                float plotW = Math.Max(10f, right - left);
                float plotH = Math.Max(10f, bottom - top);

                int maxVal = Math.Max(5, Series.SelectMany(s => s.Counts).DefaultIfEmpty(0).Max());

                canvas.StrokeColor = IsDark ? Color.FromArgb("#4A1D35") : Color.FromArgb("#F2D5E0");
                canvas.StrokeSize = 1;
                canvas.FontColor = IsDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#3B0D24");
                canvas.FontSize = 10;

                for (int i = 0; i <= 4; i++)
                {
                    float y = bottom - (plotH * i / 4f);
                    canvas.DrawLine(left, y, right, y);
                    int tickVal = (int)Math.Round(maxVal * i / 4.0);
                    canvas.DrawString(tickVal.ToString(), 2, y - 6, 28, 12, HorizontalAlignment.Right, VerticalAlignment.Center);
                }

                for (int i = 0; i < Years.Length; i++)
                {
                    float x = Years.Length == 1 ? left + plotW / 2f : left + (plotW * i / (Years.Length - 1));
                    canvas.DrawString(Years[i], x - 20, bottom + 6, 40, 16, HorizontalAlignment.Center, VerticalAlignment.Center);
                }

                foreach (var s in Series)
                {
                    canvas.StrokeColor = s.Color;
                    canvas.StrokeSize = 2.5f;
                    canvas.FillColor = s.Color;

                    PointF? prev = null;
                    for (int i = 0; i < Years.Length; i++)
                    {
                        int val = i < s.Counts.Length ? s.Counts[i] : 0;
                        float x = Years.Length == 1 ? left + plotW / 2f : left + (plotW * i / (Years.Length - 1));
                        float y = bottom - (plotH * val / maxVal);
                        var pt = new PointF(x, y);

                        if (prev.HasValue)
                            canvas.DrawLine(prev.Value, pt);

                        canvas.FillCircle(pt, 4.5f);
                        prev = pt;
                    }
                }
            }
        }

        private sealed class SurvivalBarDrawable : IDrawable
        {
            public bool IsDark { get; set; }
            public List<(string Label, double Pct, int Grad, int Total, Color Color)> Bars { get; set; } = [];

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.FillColor = IsDark ? Color.FromArgb("#180A12") : Colors.White;
                canvas.FillRectangle(dirtyRect);

                if (Bars.Count == 0) return;

                float left = 36f, right = dirtyRect.Width - 12f, top = 22f, bottom = dirtyRect.Height - 28f;
                float plotW = Math.Max(10f, right - left);
                float plotH = Math.Max(10f, bottom - top);

                canvas.StrokeColor = IsDark ? Color.FromArgb("#4A1D35") : Color.FromArgb("#F2D5E0");
                canvas.StrokeSize = 1;
                canvas.FontColor = IsDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#3B0D24");
                canvas.FontSize = 10;

                for (int p = 0; p <= 100; p += 25)
                {
                    float y = bottom - (plotH * p / 100f);
                    canvas.DrawLine(left, y, right, y);
                    canvas.DrawString($"{p}%", 2, y - 6, 30, 12, HorizontalAlignment.Right, VerticalAlignment.Center);
                }

                float slotW = plotW / Bars.Count;
                float barW = Math.Max(16f, slotW * 0.55f);

                for (int i = 0; i < Bars.Count; i++)
                {
                    var b = Bars[i];
                    float cx = left + slotW * i + slotW / 2f;
                    float bh = (float)(plotH * Math.Clamp(b.Pct, 0, 100) / 100.0);
                    float bx = cx - barW / 2f;
                    float by = bottom - bh;

                    canvas.FillColor = b.Color;
                    canvas.FillRectangle(bx, by, barW, bh);

                    canvas.DrawString($"{b.Pct:0.#}%", cx - 26, Math.Max(2, by - 14), 52, 12, HorizontalAlignment.Center, VerticalAlignment.Center);
                    canvas.DrawString(b.Label.Split(' ')[0], cx - 32, bottom + 6, 64, 16, HorizontalAlignment.Center, VerticalAlignment.Center);
                }
            }
        }

        private sealed class StatusPieDrawable : IDrawable
        {
            public bool IsDark { get; set; }
            public List<(string Label, int Count, Color Color)> Slices { get; set; } = [];

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                Color bgColor = IsDark ? Color.FromArgb("#180A12") : Colors.White;
                canvas.FillColor = bgColor;
                canvas.FillRectangle(dirtyRect);

                int total = Slices.Sum(s => s.Count);
                if (total <= 0)
                {
                    canvas.FontColor = IsDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#69143E");
                    canvas.FontSize = 12;
                    canvas.DrawString("No status records yet", 0, 0, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Center, VerticalAlignment.Center);
                    return;
                }

                float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) * 0.42f;
                float cx = dirtyRect.Width / 2f;
                float cy = dirtyRect.Height / 2f;

                float startAngleDeg = -90f;
                foreach (var slice in Slices)
                {
                    if (slice.Count <= 0) continue;

                    float sweepDeg = 360f * slice.Count / total;
                    int steps = Math.Max(8, (int)Math.Ceiling(sweepDeg / 3f));

                    var path = new PathF();
                    path.MoveTo(cx, cy);

                    for (int s = 0; s <= steps; s++)
                    {
                        float angleRad = (startAngleDeg + (sweepDeg * s / steps)) * (MathF.PI / 180f);
                        float x = cx + radius * MathF.Cos(angleRad);
                        float y = cy + radius * MathF.Sin(angleRad);
                        path.LineTo(x, y);
                    }

                    path.Close();

                    canvas.FillColor = slice.Color;
                    canvas.FillPath(path);

                    canvas.StrokeColor = bgColor;
                    canvas.StrokeSize = 2f;
                    canvas.DrawPath(path);

                    startAngleDeg += sweepDeg;
                }
            }
        }
    }
}