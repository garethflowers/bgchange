﻿//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Gareth Flowers">
// Copyright (c) Gareth Flowers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GarethFlowers.BGChange
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
        /// INI File Settings.
        /// </summary>
        private const int SPIF_SENDWININICHANGE = 2;

        /// <summary>
        /// Update INI Files Setting.
        /// </summary>
        private const int SPIF_UPDATEINIFILE = 1;

        /// <summary>
        /// Prevents a default instance of the <see cref="NativeMethods"/> class from being created.
        /// </summary>
        private NativeMethods()
        {
        }

        /// <summary>
        /// Set the background image.
        /// </summary>
        /// <param name="imageLocation">Location of the Background Image.</param>
        /// <returns>Result of setting the background.</returns>
        public static bool SetBackground(string imageLocation)
        {
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE))
            {
                throw new System.ComponentModel.Win32Exception();
            }

            return true;
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
        private static extern bool SystemParametersInfo(int action, int parameter, string lpvParam, int winIni);
    }
}
