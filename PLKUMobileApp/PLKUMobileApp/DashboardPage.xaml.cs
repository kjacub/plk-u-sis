using MySqlConnector;

namespace PLKUMobileApp
{
    public partial class DashboardPage : ContentPage
    {
        private string ConnectionString
        {
            get
            {
                string pwd = Environment.GetEnvironmentVariable("PLK_DB_PASSWORD") ?? ;
                return $"Server=10.0.2.2;Port=3306;Database=plk_u_sis_db;Uid=root;Pwd={pwd};";
            }
        }

        public DashboardPage()
        {
            InitializeComponent();
            ApplyTheme(ThemeManager.IsDarkMode);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ThemeManager.ThemeChanged += ApplyTheme;
            ApplyTheme(ThemeManager.IsDarkMode);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ThemeManager.ThemeChanged -= ApplyTheme;
        }

        private void OnToggleDarkModeClicked(object? sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private void ApplyTheme(bool isDark)
        {
            BackgroundColor = isDark ? Color.FromArgb("#1A0B14") : Color.FromArgb("#B85D85");

            Color cardBg = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#FCEEF2");
            Color cardStroke = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#7A1C4B");
            Color headingColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");
            Color labelColor = isDark ? Color.FromArgb("#FFE4EE") : Color.FromArgb("#3B0D24");
            Color inputBg = isDark ? Color.FromArgb("#180A12") : Color.FromArgb("#FFF5F8");
            Color inputText = isDark ? Color.FromArgb("#FFF0F6") : Color.FromArgb("#2B091B");
            Color inputPlaceholder = isDark ? Color.FromArgb("#B8889E") : Color.FromArgb("#9E7B8B");
            Color secBtnBg = isDark ? Color.FromArgb("#3B192D") : Color.FromArgb("#F8D7E4");
            Color secBtnText = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");

            cardHeader.BackgroundColor = cardBg;
            cardHeader.Stroke = cardStroke;

            cardForm.BackgroundColor = cardBg;
            cardForm.Stroke = cardStroke;

            cardNav.BackgroundColor = cardBg;
            cardNav.Stroke = cardStroke;

            lblDashTitle.TextColor = headingColor;
            lblDashSubtitle.TextColor = isDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#7A2850");
            lblFormHeading.TextColor = headingColor;

            lblStudentId.TextColor = labelColor;
            lblGender.TextColor = labelColor;
            lblFirstName.TextColor = labelColor;
            lblLastName.TextColor = labelColor;
            lblMiddleName.TextColor = labelColor;
            lblContact.TextColor = labelColor;
            lblProgram.TextColor = labelColor;
            lblYearLevel.TextColor = labelColor;
            lblStatus.TextColor = labelColor;
            lblEnrollYear.TextColor = labelColor;

            RadioButton[] genderButtons = [rbMale, rbFemale, rbOther];
            foreach (var rb in genderButtons)
            {
                rb.BackgroundColor = Colors.Transparent;
                rb.TextColor = labelColor;
            }

            Border[] inputBorders =
            [
                borderStudentId, borderFirstName, borderLastName,
                borderMiddleName, borderContact, borderProgram,
                borderYearLevel, borderStatus, borderEnrollYear
            ];
            foreach (var b in inputBorders)
            {
                b.BackgroundColor = inputBg;
                b.Stroke = cardStroke;
            }

            Entry[] entries = [entryStudentId, entryFirstName, entryLastName, entryMiddleName, entryContact];
            foreach (var ent in entries)
            {
                ent.TextColor = inputText;
                ent.PlaceholderColor = inputPlaceholder;
            }

            Picker[] pickers = [pickerProgram, pickerYearLevel, pickerStatus, pickerEnrollmentYear];
            foreach (var p in pickers)
            {
                p.TextColor = inputText;
                p.TitleColor = inputPlaceholder;
            }

            Button[] secondaryButtons = [btnClearFields, btnViewDirectory, btnViewCharts, btnExitDashboard];
            foreach (var btn in secondaryButtons)
            {
                btn.BackgroundColor = secBtnBg;
                btn.BorderColor = cardStroke;
                btn.TextColor = secBtnText;
            }

            lblFooter.TextColor = isDark ? Color.FromArgb("#D8A8BE") : Color.FromArgb("#FCEEF2");

            btnDarkMode.Text = isDark ? "☀️ Light" : "🌙 Dark";
            btnDarkMode.BackgroundColor = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#69143E");
            btnDarkMode.TextColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderColor = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderWidth = 1;
        }

        private string GetSelectedGender()
        {
            if (rbMale.IsChecked) return "Male";
            if (rbOther.IsChecked) return "Other";
            return "Female";
        }

        private async Task<bool> ValidateAllFieldsAsync()
        {
            List<string> missingFields = new();

            if (string.IsNullOrWhiteSpace(entryStudentId.Text))
                missingFields.Add("Student ID");

            if (string.IsNullOrWhiteSpace(entryFirstName.Text))
                missingFields.Add("First Name");

            if (string.IsNullOrWhiteSpace(entryLastName.Text))
                missingFields.Add("Last Name");

            if (string.IsNullOrWhiteSpace(entryMiddleName.Text))
                missingFields.Add("Middle Name");

            if (string.IsNullOrWhiteSpace(entryContact.Text))
                missingFields.Add("Contact Number");

            if (pickerProgram.SelectedIndex < 0)
                missingFields.Add("Program");

            if (pickerYearLevel.SelectedIndex < 0)
                missingFields.Add("Year Level");

            if (pickerStatus.SelectedIndex < 0)
                missingFields.Add("Academic Status");

            if (pickerEnrollmentYear.SelectedIndex < 0)
                missingFields.Add("Enrollment Year");

            if (missingFields.Count > 0)
            {
                string listText = string.Join("\n• ", missingFields);
                await DisplayAlertAsync(
                    "Incomplete Fields",
                    $"Please fill out all required fields:\n• {listText}",
                    "OK");
                return false;
            }

            return true;
        }

        private async void OnAddStudentClicked(object? sender, EventArgs e)
        {
            if (!await ValidateAllFieldsAsync())
                return;

            string id = entryStudentId.Text!.Trim();
            string first = entryFirstName.Text!.Trim();
            string middle = entryMiddleName.Text!.Trim();
            string last = entryLastName.Text!.Trim();
            string gender = GetSelectedGender();
            string contact = entryContact.Text!.Trim();
            string program = pickerProgram.SelectedItem!.ToString()!;
            string year = pickerYearLevel.SelectedItem!.ToString()!;
            string status = pickerStatus.SelectedItem!.ToString()!;
            string enrollYear = pickerEnrollmentYear.SelectedItem!.ToString()!;

            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                string sql = @"INSERT INTO students 
                               (student_id, first_name, middle_name, last_name, gender, year_level, program, contact_number, enrollment_year, status)
                               VALUES (@id, @first, @middle, @last, @gender, @year, @program, @contact, @enrollYear, @status)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@first", first);
                cmd.Parameters.AddWithValue("@middle", middle);
                cmd.Parameters.AddWithValue("@last", last);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@enrollYear", enrollYear);
                cmd.Parameters.AddWithValue("@status", status);

                await cmd.ExecuteNonQueryAsync();
                await DisplayAlertAsync("Success", "Student record added successfully!", "OK");
                ClearInputs();
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        private async void OnUpdateStudentClicked(object? sender, EventArgs e)
        {
            if (!await ValidateAllFieldsAsync())
                return;

            string id = entryStudentId.Text!.Trim();

            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                string sql = @"UPDATE students SET 
                               first_name = @first,
                               middle_name = @middle,
                               last_name = @last,
                               gender = @gender,
                               year_level = @year,
                               program = @program,
                               contact_number = @contact,
                               enrollment_year = @enrollYear,
                               status = @status
                               WHERE student_id = @id";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@first", entryFirstName.Text!.Trim());
                cmd.Parameters.AddWithValue("@middle", entryMiddleName.Text!.Trim());
                cmd.Parameters.AddWithValue("@last", entryLastName.Text!.Trim());
                cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                cmd.Parameters.AddWithValue("@year", pickerYearLevel.SelectedItem!.ToString()!);
                cmd.Parameters.AddWithValue("@program", pickerProgram.SelectedItem!.ToString()!);
                cmd.Parameters.AddWithValue("@contact", entryContact.Text!.Trim());
                cmd.Parameters.AddWithValue("@enrollYear", pickerEnrollmentYear.SelectedItem!.ToString()!);
                cmd.Parameters.AddWithValue("@status", pickerStatus.SelectedItem!.ToString()!);

                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    await DisplayAlertAsync("Updated", "Student record updated successfully!", "OK");
                    ClearInputs();
                }
                else
                {
                    await DisplayAlertAsync("Not Found", $"No student found with ID '{id}'.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        private async void OnDeleteStudentClicked(object? sender, EventArgs e)
        {
            string id = entryStudentId.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(id))
            {
                await DisplayAlertAsync("Warning", "Please enter a Student ID to delete.", "OK");
                return;
            }

            bool confirm = await DisplayAlertAsync(
                "Confirm Delete",
                $"Are you sure you want to delete student record '{id}'?",
                "Yes, Delete",
                "Cancel");

            if (!confirm)
                return;

            try
            {
                using var conn = new MySqlConnection(ConnectionString);
                await conn.OpenAsync();

                string sql = "DELETE FROM students WHERE student_id = @id";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    await DisplayAlertAsync("Deleted", $"Student record '{id}' has been deleted.", "OK");
                    ClearInputs();
                }
                else
                {
                    await DisplayAlertAsync("Not Found", $"No student found with ID '{id}'.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        private void OnClearFieldsClicked(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            entryStudentId.Text = string.Empty;
            entryFirstName.Text = string.Empty;
            entryMiddleName.Text = string.Empty;
            entryLastName.Text = string.Empty;
            entryContact.Text = string.Empty;
            rbFemale.IsChecked = true;
            pickerProgram.SelectedIndex = -1;
            pickerYearLevel.SelectedIndex = -1;
            pickerStatus.SelectedIndex = -1;
            pickerEnrollmentYear.SelectedIndex = -1;
        }

        private async void OnViewAllDirectoryClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Directory));
        }

        private async void OnViewChartsClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ChartsPage));
        }

        private async void OnExitDashboardClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}