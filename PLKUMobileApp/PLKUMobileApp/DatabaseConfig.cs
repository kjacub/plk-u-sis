using Microsoft.Maui.Storage;

namespace PLKUMobileApp
{
    public static class DatabaseConfig
    {
        private const string PasswordKey = "PLK_DB_PASSWORD";

        public static async Task<string> GetPasswordAsync()
        {
            return await SecureStorage.Default.GetAsync(PasswordKey) ?? "";
        }

        public static async Task SavePasswordAsync(string password)
        {
            await SecureStorage.Default.SetAsync(PasswordKey, password);
        }
    }
}