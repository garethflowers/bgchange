//-----------------------------------------------------------------------
// <copyright file="Security.cs" company="Gareth Flowers">
// Copyright (c) Gareth Flowers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GarethFlowers.BGChange
{
    /// <summary>
    /// Provides static functions
    /// </summary>
    internal sealed class Security
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Security"/> class from being created.
        /// </summary>
        private Security()
        {
        }

        /// <summary>
        /// Checks to see if the current user is an administrator.
        /// </summary>
        /// <returns>True, if the user is an administrator.</returns>
        public static bool IsUserAdministrator()
        {
            bool isAdmin;

            try
            {
                System.Security.Principal.WindowsIdentity user = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(user);
                isAdmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            catch (System.Security.SecurityException)
            {
                isAdmin = false;
            }
            catch (System.UnauthorizedAccessException)
            {
                isAdmin = false;
            }

            return isAdmin;
        }
    }
}
