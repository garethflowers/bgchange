//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Gareth Flowers">
//     Copyright Gareth Flowers. All rights reserved.
// </copyright>
// <summary>
// Background Image Changer
// </summary>
//-----------------------------------------------------------------------

namespace GarethFlowers.BackgroundChanger
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
            if (args == null || args.Length.Equals(0))
            {
                System.Console.WriteLine("ERROR: you must specify the image location");
                return;
            }

            int style = 0;
            int tile = 1;
            string fileName = string.Empty;

            foreach (string arg in args)
            {
                switch (arg.ToUpperInvariant())
                {
                    case "/?":
                    case "-h":
                    case "--HELP":
                        System.Console.WriteLine(string.Empty);
                        System.Console.WriteLine("Sets the current background image and style.");
                        System.Console.WriteLine(string.Empty);
                        System.Console.WriteLine("BGCHANGE [/T | /C | /S] filename");
                        System.Console.WriteLine(string.Empty);
                        System.Console.WriteLine("  /T          Tiles the background image across the screen.");
                        System.Console.WriteLine("  /C          Centers the background image on the screen.");
                        System.Console.WriteLine("  /S          Stretchs the background image to fill the screen.");
                        System.Console.WriteLine("  filename    Image filename to apply as a background.");
                        return;
                    case "/T":
                        // tile
                        style = 0;
                        tile = 1;
                        break;
                    case "/C":
                        // center
                        style = 0;
                        tile = 0;
                        break;
                    case "/S":
                        // stretch
                        style = 2;
                        tile = 0;
                        break;
                    default:
                        if (!System.IO.File.Exists(arg))
                        {
                            System.Console.WriteLine("ERROR: the image location is invalid");
                            return;
                        }
                        else
                        {
                            fileName = arg;
                        }

                        break;
                }
            }

            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true))
            {
                key.SetValue(@"WallpaperStyle", style.ToString());
                key.SetValue(@"TileWallpaper", tile.ToString());
                key.SetValue(@"Wallpaper", fileName);
            }

            NativeMethods.SetBackground(fileName);
        }
    }
}
