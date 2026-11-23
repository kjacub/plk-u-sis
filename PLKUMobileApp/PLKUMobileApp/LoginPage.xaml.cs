using MySqlConnector;

namespace PLKUMobileApp
{
    public partial class LoginPage : ContentPage
    {
        private IDispatcherTimer? _clockTimer;

        public LoginPage()
        {
            InitializeComponent();
            UpdateClock();
            StartClockTimer();
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
            Color primaryText = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#69143E");
            Color secondaryText = isDark ? Color.FromArgb("#E8C4D4") : Color.FromArgb("#7A2850");
            Color labelText = isDark ? Color.FromArgb("#FFE4EE") : Color.FromArgb("#3B0D24");

            cardHeader.BackgroundColor = cardBg;
            cardHeader.Stroke = cardStroke;

            panelLogin.BackgroundColor = cardBg;
            panelLogin.Stroke = cardStroke;

            cardCharter.BackgroundColor = cardBg;
            cardCharter.Stroke = cardStroke;

            cardClock.BackgroundColor = cardBg;
            cardClock.Stroke = cardStroke;

            panelInfo.BackgroundColor = isDark ? Color.FromArgb("#24101C") : Color.FromArgb("#FADADD");
            panelInfo.Stroke = cardStroke;

            cardInfoBody.BackgroundColor = isDark ? Color.FromArgb("#180A12") : Color.FromArgb("#FFF5F8");
            cardInfoBody.Stroke = isDark ? Color.FromArgb("#6A2C4B") : Color.FromArgb("#E1BEE7");

            lblBrandTitle.TextColor = primaryText;
            lblBrandSubtitle.TextColor = primaryText;
            lblWelcome.TextColor = primaryText;
            lblWelcomeSub.TextColor = secondaryText;
            lblAdminHeading.TextColor = primaryText;
            lblAdminId.TextColor = labelText;
            lblPassword.TextColor = labelText;
            lblShowPassword.TextColor = primaryText;
            lblCharterMain.TextColor = primaryText;
            lblClockTitle.TextColor = primaryText;
            lblSystemDate.TextColor = primaryText;
            lblSystemTime.TextColor = primaryText;
            lblInfoTitle.TextColor = primaryText;
            lblInfoSubtitle.TextColor = secondaryText;
            lblInfoBody.TextColor = isDark ? Color.FromArgb("#F5E6EC") : Color.FromArgb("#2B091B");
            lblFooter.TextColor = isDark ? Color.FromArgb("#D8A8BE") : Color.FromArgb("#FCEEF2");

            btnDarkMode.Text = isDark ? "☀️ Light" : "🌙 Dark";
            btnDarkMode.BackgroundColor = isDark ? Color.FromArgb("#2B1321") : Color.FromArgb("#69143E");
            btnDarkMode.TextColor = isDark ? Color.FromArgb("#F8BBD0") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderColor = isDark ? Color.FromArgb("#D85A9A") : Color.FromArgb("#FCEEF2");
            btnDarkMode.BorderWidth = 1;
        }

        private void StartClockTimer()
        {
            _clockTimer = Dispatcher.CreateTimer();
            _clockTimer.Interval = TimeSpan.FromSeconds(1);
            _clockTimer.Tick += (_, _) => UpdateClock();
            _clockTimer.Start();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            lblSystemDate.Text = now.ToString("dddd, MMMM dd, yyyy");
            lblSystemTime.Text = now.ToString("hh:mm:ss tt");
        }

        private void OnShowPasswordCheckedChanged(object? sender, CheckedChangedEventArgs e)
        {
            entryPassword.IsPassword = !e.Value;
        }

        private void OnOpenInfoClicked(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            string target = btn.CommandParameter?.ToString() ?? "";

            if (target == "CHARTER")
            {
                lblInfoTitle.Text = "PLK UNIVERSITY CHARTER & AMENDMENTS";
                lblInfoSubtitle.Text = "Charter of 10 Rules and Amendments";
                lblInfoBody.Text =
                    "1. Vision & Mission\n" +
                    "Vision: PLK University is a community where every person, regardless of background, is equal, confident, and radiant, with a sharp mind and a generous heart.\n" +
                    "Mission: We commit to develop learners who carry themselves with confidence and grace, who think critically and act kindly, and who use their intelligence for their own growth and for the good of the community.\n\n" +
                    "2. Honest & Integrity\n" +
                    "Every member of the university tells the truth, credits others' work, and owns their mistakes. Cheating, plagiarism, and falsifying records have no place here, and honest mistakes are met with guidance, not humiliation.\n\n" +
                    "3. Equality & Dignity\n" +
                    "Everyone is treated as an equal, whatever their gender, background, belief, ability, or status. Bullying, discrimination, and harassment, in person or online, are not tolerated.\n\n" +
                    "4. Respect & Consent\n" +
                    "Personal space, boundaries, and privacy are respected. Consent is required in all interactions, and no one's photos or personal information may be shared without permission.\n\n" +
                    "5. Academic Excellence with Heart\n" +
                    "Learners are expected to do their best, and to help classmates grow rather than compete destructively. Collaboration is rewarded as much as individual achievement.\n\n" +
                    "6. Freedom of Dress & Expression\n" +
                    "Anyone may wear what they want, within basic safety and the needs of a lab or workshop. No one may pass judgement on another person's clothing or body, especially sexist judgement. Comments, jokes, or rules that shame a person for how they dress are treated as harassment.\n\n" +
                    "7. Responsible Technology & AI Use\n" +
                    "Digital tools and AI may be used for learning, but they must be disclosed where required, never used to deceive, and never used to create fake, harmful, or embarrassing content about another person.\n\n" +
                    "8. Mental Health & Well-Being\n" +
                    "Rest, balance, and asking for help are normal and encouraged. The university provides safe, confidential support, and no one is judged for using it.\n\n" +
                    "9. Community & Service\n" +
                    "Every member contributes to the community through service, volunteering, or helping others, because success means little if it isn't shared.\n\n" +
                    "10. Sustainability & Shared Space\n" +
                    "Campus facilities, equipment, and the environment are cared for by all. Waste is reduced, spaces are kept clean, and everyone leaves a place better than they found it.";
                panelInfo.IsVisible = true;
            }
            else if (target == "HISTORY")
            {
                lblInfoTitle.Text = "PLK UNIVERSITY HISTORY";
                lblInfoSubtitle.Text = "A Brief History of the University";
                lblInfoBody.Text =
                    "PLK University was founded in 2006 upon a single conviction: that girls should be given a place where they are free to imagine, to learn, and to lead without limitation. Inspired by the vision of Ruth Handler, the creator of Barbie, who believed that a girl could become anything she dared to imagine, the founders established the university as an institution made by girls, for girls.\n\n" +
                    "Its first motto, \"Imagine It. Become It.\", was placed above the entrance and has guided the university ever since. In its earliest years the university was modest in size, beginning with only thirty-two students, a small faculty, and a library of three shelves. Yet from these humble beginnings arose a spirit of initiative that came to define the institution. Students formed a robotics club from recycled materials, launched a student publication, and organized the university's first science fair in a corridor, as the gymnasium had not yet been built. The original constitution of the university was a single page, which pledged that every student would be heard, that every idea would be respected, and that no aspiration would be considered too great for the classroom.\n\n" +
                    "As the student body grew, the need for a more comprehensive governing document became evident. The expansion of the constitution was undertaken through the dedicated efforts of three student leaders: Princess Joie Villar, Leigh Anika Punzalan, and Kate Jewell Curativo.\n\n" +
                    "Through a full semester of deliberation, their collaboration produced the enlarged constitution that is read at the university's opening ceremonies to this day. Today, PLK University stands as a community defined by sisterhood, service, and the shared pursuit of excellence. It remains faithful to the ideals of its founding, and it invites each new student to understand that the history of the university is still being written, and that she, too, has a chapter to contribute.";
                panelInfo.IsVisible = true;
            }
            else if (target == "FACULTY")
            {
                lblInfoTitle.Text = "PLK UNIVERSITY PROGRAMS & FACULTY";
                lblInfoSubtitle.Text = "Meet our Academic Heads, Professors, and Support Staff";
                lblInfoBody.Text =
                    "OFFICE OF THE PRESIDENT\n" +
                    "Dr. Barbie Millicent F. Roberts — President\n\n" +
                    "OFFICE OF THE DEAN\n" +
                    "Dr. Dame Devin D. Batterbony — Dean of the University\n\n" +
                    "BS in Historical Fashion\n" +
                    "Program Head: Princess D. Anneliese\n" +
                    "1. Prof. Genevieve Yulo\n" +
                    "2. Prof. Rapunzel C. Onni\n" +
                    "3. Prof. Odette R. Gigil\n" +
                    "4. Prof. Clara F. Yaass\n" +
                    "5. Prof. Thumbelina D. Haggardo\n" +
                    "6. Prof. Erika A. Churvaloo\n" +
                    "7. Prof. Deli C. Chaka\n\n" +
                    "BS in Haute Couture and Luxury Fashion Design\n" +
                    "Program Head: Raquelle Y. Datingan\n" +
                    "1. Prof. Teresa Inday\n" +
                    "2. Prof. Nikki D. Lowkey\n" +
                    "3. Prof. Summer S. Every\n" +
                    "4. Prof. Brooklyn Petchay\n" +
                    "5. Prof. Daisy B. Kalabaw\n" +
                    "6. Prof. Renee C. Pastilan\n" +
                    "7. Prof. Ryan Kamote\n\n" +
                    "BS in Cosmetic Science\n" +
                    "Program Head: Midge S. Pagod\n" +
                    "1. Prof. Hadley C. Kiber\n" +
                    "2. Prof. Isla A. Lastikman\n" +
                    "3. Prof. Blair Bakekang\n" +
                    "4. Prof. Christie P. Pepito\n" +
                    "5. Prof. Kelly Penduko\n" +
                    "6. Prof. Stacie C. Dora\n" +
                    "7. Prof. Ken Marimar\n\n" +
                    "BS in Floriculture and Botanical Design\n" +
                    "Program Head: Elina C. Rodrigiz\n" +
                    "1. Prof. Bibble G. Bernardo\n" +
                    "2. Prof. Hue M. Tolentino\n" +
                    "3. Prof. Azura K. Navarro\n" +
                    "4. Prof. Dandelion Miller\n" +
                    "5. Prof. Mariposa H. Domingo\n" +
                    "6. Prof. Zinzie F. Sabando\n" +
                    "7. Prof. Rosella W. Jimenez\n\n" +
                    "FACULTY & ADMINISTRATIVE STAFF\n" +
                    "• Allan Abubakar — University Registrar\n" +
                    "• Barbie Wong — Guidance and Counseling Head\n" +
                    "• Anika Chowdhury — Head Librarian\n" +
                    "• Taffy Dalia Cohen — Campus Pet Warden\n" +
                    "• Sasha Adeyemi — Student Council Adviser\n" +
                    "• Gloria Kim — Director of Student Affairs\n" +
                    "• Chelsea Margaux Delacroix — Director of Student Welfare";
                panelInfo.IsVisible = true;
            }
        }

        private void OnBackToLoginClicked(object? sender, EventArgs e)
        {
            panelInfo.IsVisible = false;
        }

        private async Task<bool> EnsureDatabasePasswordAsync()
        {
            string pwd = await DatabaseConfig.GetPasswordAsync();

            if (string.IsNullOrEmpty(pwd))
            {
                var passwordEntry = new Entry
                {
                    Placeholder = "Enter database password",
                    IsPassword = true
                };

                var completion = new TaskCompletionSource<string?>();

                var saveButton = new Button
                {
                    Text = "Connect"
                };

                var cancelButton = new Button
                {
                    Text = "Cancel"
                };

                var passwordPage = new ContentPage
                {
                    Content = new VerticalStackLayout
                    {
                        Padding = 25,
                        Spacing = 15,
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                {
                    new Label
                    {
                        Text = "Database Configuration",
                        FontSize = 24,
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label
                    {
                        Text = "Enter the MySQL database password."
                    },
                    passwordEntry,
                    saveButton,
                    cancelButton
                }
                    }
                };

                saveButton.Clicked += (s, e) =>
                {
                    completion.TrySetResult(passwordEntry.Text);
                };

                cancelButton.Clicked += (s, e) =>
                {
                    completion.TrySetResult(null);
                };

                passwordPage.Disappearing += (s, e) =>
                {
                    completion.TrySetResult(null);
                };

                await Navigation.PushModalAsync(passwordPage);

                pwd = await completion.Task ?? "";

                if (Navigation.ModalStack.Contains(passwordPage))
                    await Navigation.PopModalAsync();

                if (string.IsNullOrEmpty(pwd))
                    return false;
            }

            try
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = "10.0.2.2",
                    Port = 3306,
                    Database = "plk_u_sis_db",
                    UserID = "capstone_user",
                    Password = pwd,
                    ConnectionTimeout = 10
                };

                using var conn = new MySqlConnection(
                    builder.ConnectionString);

                await conn.OpenAsync();

                await DatabaseConfig.SavePasswordAsync(pwd);

                return true;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Storage.SecureStorage.Default
                    .Remove("PLK_DB_PASSWORD");

                await DisplayAlertAsync(
                "Database Connection Failed",
                $"{ex.GetType().Name}: {ex.Message}",
                "OK");

                return false;
            }
        }
        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            string username = entryUsername.Text?.Trim() ?? "";
            string password = entryPassword.Text ?? "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblLoginError.Text = "Please enter both Admin ID and Password.";
                lblLoginError.IsVisible = true;
                return;
            }

            if ((username.Equals("admin05611", StringComparison.OrdinalIgnoreCase) ||
                 username.Equals("admin14090", StringComparison.OrdinalIgnoreCase) ||
                 username.Equals("admin06154", StringComparison.OrdinalIgnoreCase)) &&
                 password == "projecthailmary")
            {
                lblLoginError.IsVisible = false;

                bool databaseReady = await EnsureDatabasePasswordAsync();

                if (!databaseReady)
                    return;

                await Shell.Current.GoToAsync(nameof(DashboardPage));
            }
            else
            {
                lblLoginError.Text = "Invalid credentials.";
                lblLoginError.IsVisible = true;
            }
        }
    }
}