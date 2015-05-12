
namespace GarethFlowers.BGChange
{
    public sealed class BackgroundUpdater
    {
        private BackgroundUpdater()
        {
        }

        public static void Apply(string fileName, int style, int tile)
        {
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true))
            {
                key.SetValue("WallpaperStyle", style.ToString(System.Globalization.CultureInfo.InvariantCulture));
                key.SetValue("TileWallpaper", tile.ToString(System.Globalization.CultureInfo.InvariantCulture));
                key.SetValue("Wallpaper", fileName);
            }

            if (Security.IsUserAdministrator())
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true))
                {
                    if (key.GetValue("Wallpaper", null) != null)
                    {
                        key.SetValue("Wallpaper", fileName);
                    }
                    if (key.GetValue("WallpaperStyle", null) != null)
                    {
                        key.SetValue("WallpaperStyle", style.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }

            NativeMethods.SetBackground(fileName);
        }
    }
}
