using System;
using System.Collections.Generic;
using System.Text;

namespace PLKUMobileApp
{
    public static class ThemeManager
    {
        public static bool IsDarkMode { get; private set; }

        public static event Action<bool>? ThemeChanged;

        public static void SetDarkMode(bool enabled)
        {
            if (IsDarkMode == enabled) return;

            IsDarkMode = enabled;

            if (Application.Current is not null)
            {
                Application.Current.UserAppTheme = enabled ? AppTheme.Dark : AppTheme.Light;
            }

            ThemeChanged?.Invoke(enabled);
        }

        public static void Toggle()
        {
            SetDarkMode(!IsDarkMode);
        }
    }
}

