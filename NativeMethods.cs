//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Gareth Flowers">
//     Copyright Gareth Flowers. All rights reserved.
// </copyright>
// <summary>
// Background Image Changer
// </summary>
//-----------------------------------------------------------------------

namespace GarethFlowers.BackgroundChanger
{
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    public sealed class NativeMethods
    {
        /// <summary>
        /// Desktop Wallpaper Setting.
        /// </summary>
        private const int SPI_SETDESKWALLPAPER = 20;

        /// <summary>
        /// Update INI Files Setting.
        /// </summary>
        private const int SPIF_UPDATEINIFILE = 1;

        /// <summary>
        /// INI File Settings.
        /// </summary>
        private const int SPIF_SENDWININICHANGE = 2;

        /// <summary>
        /// Prevents a default instance of the NativeMethods class from being created.
        /// </summary>
        private NativeMethods()
        {
            // n/a
        }

        /// <summary>
        /// Set the background image.
        /// </summary>
        /// <param name="imageLocation">Location of the Background Image.</param>
        /// <returns>Result of setting the background.</returns>
        public static int SetBackground(string imageLocation)
        {
            return SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        /// <summary>
        /// Execute the SystemParametersInfo().
        /// </summary>
        /// <param name="action">Action Value.</param>
        /// <param name="parameter">Parameter Value.</param>
        /// <param name="lpvParam">Alternative Parameter Value.</param>
        /// <param name="winIni">INI File Value.</param>
        /// <returns>Result of setting the background.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int SystemParametersInfo(int action, int parameter, string lpvParam, int winIni);
    }
}
