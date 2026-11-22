namespace PLKUMobileApp
{
    public class Student
    {
        public string StudentId { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public string YearLevel { get; set; } = "";
        public string Program { get; set; } = "";
        public string ContactNumber { get; set; } = "";
        public string EnrollmentYear { get; set; } = "";
        public string Status { get; set; } = "";

        public string FullName =>
            string.IsNullOrWhiteSpace(MiddleName)
                ? $"{FirstName} {LastName}".Trim()
                : $"{FirstName} {MiddleName} {LastName}".Trim();

        public string CleanStatus =>
            string.IsNullOrWhiteSpace(Status) ? "Active" : Status.Trim();

        public string ShortProgram => Program switch
        {
            "BS in Cosmetic Science" => "Cosmetic Science",
            "BS in Floriculture and Botanical Design" => "Floriculture",
            "BS in Historical Fashion" => "Historical Fashion",
            "BS in Haute Couture and Luxury Fashion Design" => "Haute Couture",
            _ => Program
        };

        public Color StatusBadgeColor => CleanStatus.ToLowerInvariant() switch
        {
            "enrolled" or "active" => Color.FromArgb("#2E7D32"),
            "irregular" => Color.FromArgb("#EF6C00"),
            "graduated" => Color.FromArgb("#6A1B9A"),
            "dropped" or "transferred out" => Color.FromArgb("#C62828"),
            _ => Color.FromArgb("#89235B")
        };
    }
}

