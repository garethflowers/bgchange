namespace GarethFlowers.BGChange
{
    internal sealed class Security
    {
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