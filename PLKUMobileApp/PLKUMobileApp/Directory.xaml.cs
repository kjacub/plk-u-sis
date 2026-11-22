using MySqlConnector;
using System.Collections.ObjectModel;

namespace PLKUMobileApp
{
    public partial class Directory : ContentPage
    {
        private readonly List<Student> _allStudents = new();
        public ObservableCollection<Student> FilteredStudents { get; } = new();

        private string _selectedYear = "ALL";
        private string _selectedProgram = "ALL";

        private string ConnectionString
        {
            get
            {
                string pwd = Environment.GetEnvironmentVariable("PLK_DB_PASSWORD") ?? ;
                return $"Server=10.0.2.2;Port=3306;Database=plk_u_sis_db;Uid=root;Pwd={pwd};";
            }
        }

        public Directory()
        {
            InitializeComponent();
            cvStudents.ItemsSource = FilteredStudents;
            SyncThemeUI(ThemeManager.IsDarkMode);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ThemeManager.ThemeChanged += SyncThemeUI;
            SyncThemeUI(ThemeManager.IsDarkMode);
            await LoadStudentsAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ThemeManager.ThemeChanged -= SyncThemeUI;
        }

        private void SyncThemeUI(bool isDark)
        {
            btnDarkMode.Text = isDark ? "☀️ Light" : "🌙 Dark";
            btnDarkMode.BackgroundColor = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#69143E");
            btnDarkMode.TextColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderColor = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderWidth = 1;
        }

        private static string GetColumnSafe(MySqlDataReader reader, params string[] candidates)
        {
            foreach (string col in candidates)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Equals(col, StringComparison.OrdinalIgnoreCase))
                    {
                        return reader.IsDBNull(i) ? "" : reader.GetValue(i)?.ToString() ?? "";
                    }
                }
            }
            return "";
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                _allStudents.Clear();

                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                string sql = "SELECT * FROM students ORDER BY student_id ASC";
                using var cmd = new MySqlCommand(sql, conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    _allStudents.Add(new Student
                    {
                        StudentId = GetColumnSafe(reader, "student_id", "id"),
                        FirstName = GetColumnSafe(reader, "first_name", "firstname"),
                        MiddleName = GetColumnSafe(reader, "middle_name", "middlename"),
                        LastName = GetColumnSafe(reader, "last_name", "lastname"),
                        Gender = GetColumnSafe(reader, "gender", "sex"),
                        YearLevel = GetColumnSafe(reader, "year_level", "year"),
                        Program = GetColumnSafe(reader, "program", "course"),
                        ContactNumber = GetColumnSafe(reader, "contact_number", "contact"),
                        EnrollmentYear = GetColumnSafe(reader, "enrollment_year", "enroll_year"),
                        Status = GetColumnSafe(reader, "academic_status", "status", "student_status")
                    });
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                lblRecordCount.Text = "Unable to load records";
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        private void ApplyFilters()
        {
            string query = entrySearch.Text?.Trim() ?? "";
            btnClearSearch.IsVisible = !string.IsNullOrEmpty(query);

            IEnumerable<Student> results = _allStudents;

            if (_selectedYear != "ALL")
            {
                results = results.Where(s =>
                    s.YearLevel.Equals(_selectedYear, StringComparison.OrdinalIgnoreCase));
            }

            if (_selectedProgram != "ALL")
            {
                results = results.Where(s =>
                    s.Program.Equals(_selectedProgram, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                results = results.Where(s =>
                    s.StudentId.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    s.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    s.MiddleName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    s.LastName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    s.FullName.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            var list = results.ToList();
            FilteredStudents.Clear();
            foreach (var item in list)
            {
                FilteredStudents.Add(item);
            }

            lblRecordCount.Text = $"Showing {FilteredStudents.Count} of {_allStudents.Count} students";
        }

        private void entrySearch_TextChanged(object? sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearSearch_Clicked(object? sender, EventArgs e)
        {
            entrySearch.Text = string.Empty;
            ApplyFilters();
        }

        private void OnYearFilterClicked(object? sender, EventArgs e)
        {
            if (sender is not Button clickedBtn) return;
            _selectedYear = clickedBtn.ClassId ?? "ALL";

            foreach (var child in yearChipsContainer.Children)
            {
                if (child is Button btn)
                {
                    bool isSelected = btn.ClassId == _selectedYear;
                    btn.BackgroundColor = isSelected ? Color.FromArgb("#89235B") : Color.FromArgb("#FCE4EC");
                    btn.TextColor = isSelected ? Colors.White : Color.FromArgb("#4A0E2E");
                }
            }

            ApplyFilters();
        }

        private void OnProgramFilterClicked(object? sender, EventArgs e)
        {
            if (sender is not Button clickedBtn) return;
            _selectedProgram = clickedBtn.ClassId ?? "ALL";

            foreach (var child in programChipsContainer.Children)
            {
                if (child is Button btn)
                {
                    bool isSelected = btn.ClassId == _selectedProgram;
                    btn.BackgroundColor = isSelected ? Color.FromArgb("#F10291") : Color.FromArgb("#FCE4EC");
                    btn.TextColor = isSelected ? Colors.White : Color.FromArgb("#4A0E2E");
                }
            }

            ApplyFilters();
        }

        private async void refreshView_Refreshing(object? sender, EventArgs e)
        {
            await LoadStudentsAsync();
            refreshView.IsRefreshing = false;
        }

        private void OnStudentCardTapped(object? sender, TappedEventArgs e)
        {
            if (e.Parameter is not Student student) return;

            lblPopupId.Text = student.StudentId;
            lblPopupFullName.Text = student.FullName;
            lblPopupStatus.Text = student.CleanStatus;
            badgePopupStatus.BackgroundColor = student.StatusBadgeColor;

            lblPopupProgram.Text = student.Program;
            lblPopupYearLevel.Text = student.YearLevel;
            lblPopupGender.Text = student.Gender;
            lblPopupContact.Text = student.ContactNumber;
            lblPopupBatch.Text = student.EnrollmentYear;

            popupOverlay.IsVisible = true;
        }

        private void OnClosePopupTapped(object? sender, EventArgs e)
        {
            popupOverlay.IsVisible = false;
        }

        private async void OnBackClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private void OnToggleDarkModeClicked(object? sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }
    }
}