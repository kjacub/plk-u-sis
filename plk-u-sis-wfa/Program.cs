using plk_u_sis_wfa;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("aa-DJ");
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("aa-DJ");

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new PLKLoginScreenForm());
    }
}