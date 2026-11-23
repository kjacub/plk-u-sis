using MySqlConnector;

namespace PLKUMobileApp
{
    public partial class DashboardPage : ContentPage
    {
        private bool _isSanitizingLetters;
        private bool _isShowingLetterWarning;

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

        public void OnToggleDarkModeClicked(object? sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private async void OnNoLettersTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (_isSanitizingLetters || sender is not Entry entry) return;

            string current = entry.Text ?? string.Empty;
            string withoutLetters = new string(current.Where(c => !char.IsLetter(c)).ToArray());

            bool isStudentId = entry == entryStudentId;

            if (current != withoutLetters)
            {
                _isSanitizingLetters = true;
                entry.Text = withoutLetters;
                entry.CursorPosition = withoutLetters.Length;
                _isSanitizingLetters = false;

                if (isStudentId)
                    lblStudentIdWarning.IsVisible = true;
                else
                    lblContactWarning.IsVisible = true;

                if (!_isShowingLetterWarning)
                {
                    _isShowingLetterWarning = true;
                    string fieldName = isStudentId ? "Student ID" : "Contact Number";
                    await DisplayAlertAsync("Invalid Input", $"{fieldName} does not allow letters.", "OK");
                    _isShowingLetterWarning = false;
                }
            }
            else
            {
                if (isStudentId)
                    lblStudentIdWarning.IsVisible = false;
                else
                    lblContactWarning.IsVisible = false;
            }
        }

        private static bool HasNoLetters(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && !value.Any(char.IsLetter);
        }

        private void ApplyTheme(bool isDark)
        {
            BackgroundColor = isDark ? Color.FromArgb("#1A0B14") : Color.FromArgb("#B85D85");

            Color cardBg = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#FCEEF2");
            Color cardStroke = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#7A1C4B");
            Color headingColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");
            Color subColor = isDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#7A2850");
            Color labelColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#3B0D24");
            Color inputBg = isDark ? Color.FromArgb("#180A12") : Color.FromArgb("#FFF5F8");
            Color inputText = isDark ? Color.FromArgb("#FFE4EE") : Color.FromArgb("#2B091B");
            Color navBtnBg = isDark ? Color.FromArgb("#3B192D") : Color.FromArgb("#F8D7E4");

            Border[] cards = [cardHeader, cardForm, cardNav];
            foreach (var c in cards)
            {
                c.BackgroundColor = cardBg;
                c.Stroke = cardStroke;
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

            Label[] fieldLabels =
            [
                lblStudentId, lblGender, lblFirstName, lblLastName,
                lblMiddleName, lblContact, lblProgram, lblYearLevel,
                lblStatus, lblEnrollYear
            ];
            foreach (var l in fieldLabels)
                l.TextColor = labelColor;

            Entry[] entries = [entryStudentId, entryFirstName, entryLastName, entryMiddleName, entryContact];
            foreach (var ent in entries)
                ent.TextColor = inputText;

            Picker[] pickers = [pickerProgram, pickerYearLevel, pickerStatus, pickerEnrollmentYear];
            foreach (var p in pickers)
                p.TextColor = inputText;

            rbMale.TextColor = labelColor;
            rbFemale.TextColor = labelColor;
            rbOther.TextColor = labelColor;

            lblDashTitle.TextColor = headingColor;
            lblDashSubtitle.TextColor = subColor;
            lblFormHeading.TextColor = headingColor;
            lblFooter.TextColor = isDark ? Color.FromArgb("#D8A8BE") : Color.FromArgb("#FCEEF2");

            Button[] secondaryButtons = [btnClearFields, btnViewDirectory, btnViewCharts];
            foreach (var btn in secondaryButtons)
            {
                btn.BackgroundColor = navBtnBg;
                btn.BorderColor = cardStroke;
                btn.TextColor = headingColor;
            }

            btnExitDashboard.BackgroundColor = inputBg;
            btnExitDashboard.BorderColor = cardStroke;
            btnExitDashboard.TextColor = headingColor;

            btnDarkMode.Text = isDark ? "☀️ Light" : "🌙 Dark";
            btnDarkMode.BackgroundColor = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#69143E");
            btnDarkMode.TextColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderColor = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#FCEEF2");
        }

        private string GetSelectedGender()
        {
            if (rbMale.IsChecked) return "Male";
            if (rbFemale.IsChecked) return "Female";
            if (rbOther.IsChecked) return "Other";
            return "Female";
        }

        public async void OnAddStudentClicked(object? sender, EventArgs e)
        {
            string id = entryStudentId.Text?.Trim() ?? "";
            string fn = entryFirstName.Text?.Trim() ?? "";
            string mn = entryMiddleName.Text?.Trim() ?? "";
            string ln = entryLastName.Text?.Trim() ?? "";
            string contact = entryContact.Text?.Trim() ?? "";
            string program = pickerProgram.SelectedItem?.ToString() ?? "";
            string yearLevel = pickerYearLevel.SelectedItem?.ToString() ?? "";
            string status = pickerStatus.SelectedItem?.ToString() ?? "Active";
            string enrollYearStr = pickerEnrollmentYear.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fn) ||
                string.IsNullOrWhiteSpace(ln) || string.IsNullOrWhiteSpace(contact) ||
                string.IsNullOrWhiteSpace(program) || string.IsNullOrWhiteSpace(yearLevel) ||
                !int.TryParse(enrollYearStr, out int enrollYear))
            {
                await DisplayAlertAsync("Validation Error", "Please complete all required fields (Middle Name is optional).", "OK");
                return;
            }

            if (!HasNoLetters(id) || !HasNoLetters(contact))
            {
                await DisplayAlertAsync("Validation Error", "Student ID and Contact Number cannot contain letters.", "OK");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(await GetConnectionStringAsync()); await conn.OpenAsync();

                string sql = @"INSERT INTO students 
                    (student_id, first_name, middle_name, last_name, gender, year_level, program, contact_number, enrollment_year, academic_status, is_deleted)
                    VALUES (@id, @fn, @mn, @ln, @gender, @year, @program, @contact, @enrYear, @status, 0)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@mn", string.IsNullOrWhiteSpace(mn) ? DBNull.Value : mn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                cmd.Parameters.AddWithValue("@year", yearLevel);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@enrYear", enrollYear);
                cmd.Parameters.AddWithValue("@status", status);

                await cmd.ExecuteNonQueryAsync();
                await DisplayAlertAsync("Success", "Student added successfully!", "OK");
                ClearFormFields();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                await DisplayAlertAsync("Duplicate ID", $"Student ID '{id}' already exists.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        public async void OnUpdateStudentClicked(object? sender, EventArgs e)
        {
            string id = entryStudentId.Text?.Trim() ?? "";
            string fn = entryFirstName.Text?.Trim() ?? "";
            string mn = entryMiddleName.Text?.Trim() ?? "";
            string ln = entryLastName.Text?.Trim() ?? "";
            string contact = entryContact.Text?.Trim() ?? "";
            string program = pickerProgram.SelectedItem?.ToString() ?? "";
            string yearLevel = pickerYearLevel.SelectedItem?.ToString() ?? "";
            string status = pickerStatus.SelectedItem?.ToString() ?? "Active";
            string enrollYearStr = pickerEnrollmentYear.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fn) ||
                string.IsNullOrWhiteSpace(ln) || string.IsNullOrWhiteSpace(contact) ||
                string.IsNullOrWhiteSpace(program) || string.IsNullOrWhiteSpace(yearLevel) ||
                !int.TryParse(enrollYearStr, out int enrollYear))
            {
                await DisplayAlertAsync("Validation Error", "Enter a valid Student ID and complete all required fields to update.", "OK");
                return;
            }

            if (!HasNoLetters(id) || !HasNoLetters(contact))
            {
                await DisplayAlertAsync("Validation Error", "Student ID and Contact Number cannot contain letters.", "OK");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(await GetConnectionStringAsync());
                await conn.OpenAsync();

                string sql = @"UPDATE students 
                    SET first_name = @fn,
                        middle_name = @mn,
                        last_name = @ln,
                        gender = @gender,
                        year_level = @year,
                        program = @program,
                        contact_number = @contact,
                        enrollment_year = @enrYear,
                        academic_status = @status
                    WHERE student_id = @id AND is_deleted = 0";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@mn", string.IsNullOrWhiteSpace(mn) ? DBNull.Value : mn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                cmd.Parameters.AddWithValue("@year", yearLevel);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@enrYear", enrollYear);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    await DisplayAlertAsync("Updated", "Student record updated successfully!", "OK");
                    ClearFormFields();
                }
                else
                {
                    await DisplayAlertAsync("Not Found", $"No active student found with ID '{id}'.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        public async void OnDeleteStudentClicked(object? sender, EventArgs e)
        {
            string id = entryStudentId.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(id))
            {
                await DisplayAlertAsync("Validation Error", "Please enter the Student ID to delete.", "OK");
                return;
            }

            bool confirm = await DisplayAlertAsync("Confirm Delete", $"Are you sure you want to delete student '{id}'?", "Yes, Delete", "Cancel");
            if (!confirm) return;

            try
            {
                using var conn = new MySqlConnection(await GetConnectionStringAsync());
                await conn.OpenAsync();

                string sql = "UPDATE students SET is_deleted = 1 WHERE student_id = @id AND is_deleted = 0";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    await DisplayAlertAsync("Deleted", "Student record removed successfully.", "OK");
                    ClearFormFields();
                }
                else
                {
                    await DisplayAlertAsync("Not Found", $"No active student found with ID '{id}'.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Database Error", ex.Message, "OK");
            }
        }

        public void OnClearFieldsClicked(object? sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            entryStudentId.Text = string.Empty;
            entryFirstName.Text = string.Empty;
            entryMiddleName.Text = string.Empty;
            entryLastName.Text = string.Empty;
            entryContact.Text = string.Empty;
            lblStudentIdWarning.IsVisible = false;
            lblContactWarning.IsVisible = false;
            rbFemale.IsChecked = true;
            pickerProgram.SelectedIndex = -1;
            pickerYearLevel.SelectedIndex = -1;
            pickerStatus.SelectedIndex = -1;
            pickerEnrollmentYear.SelectedIndex = -1;
        }

        public async void OnViewAllDirectoryClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Directory));
        }

        public async void OnViewChartsClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ChartsPage));
        }

        public async void OnExitDashboardClicked(object? sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync("Exit Dashboard", "Return to Login screen?", "Yes", "Cancel");
            if (confirm)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}

