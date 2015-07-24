//-----------------------------------------------------------------------
// <copyright file="BackgroundUpdater.cs" company="Gareth Flowers">
// Copyright (c) Gareth Flowers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GarethFlowers.BGChange
{
    /// <summary>
    /// Provides static methods for changing background images.
    /// </summary>
    public sealed class BackgroundUpdater
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="BackgroundUpdater"/> class from being created.
        /// </summary>
        private BackgroundUpdater()
        {
        }

        /// <summary>
        /// Sets the specified file name as the current background.
        /// </summary>
        /// <param name="fileName">The file name to use as the wallpaper.</param>
        /// <param name="style">If set to 2 the wallpaper is stretched.</param>
        /// <param name="tile">If set to 1 then tiling is implemented.</param>
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
