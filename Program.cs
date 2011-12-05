//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Gareth Flowers">
//     Copyright Gareth Flowers. All rights reserved.
// </copyright>
// <summary>
// Background Image Changer
// </summary>
//-----------------------------------------------------------------------

namespace GarethFlowers.bgchange
{
    /// <summary>
    /// Application main Class.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Prevents a default instance of the Program class from being created.
        /// </summary>
        private Program()
        {
            // n/a
        }

        /// <summary>
        /// Main Method.
        /// </summary>
        /// <param name="args">Default command-line arguments.</param>
        public static void Main(string[] args)
        {
            if (!args.Length.Equals(1))
            {
                System.Console.WriteLine("ERROR: image location not defined");
                return;
            }

            if (!System.IO.File.Exists(args[0]))
            {
                System.Console.WriteLine("ERROR: image file not found");
                return;
            }

            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true))
            {
                key.SetValue(@"WallpaperStyle", "1");
                key.SetValue(@"TileWallpaper", "0");
            }

            NativeMethods.SetBackground(args[0]);
        }
    }
}
