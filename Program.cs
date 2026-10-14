using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the login screen, then the main menu. If the user chooses
            // Log Out we loop back to the login screen; closing either
            // window any other way exits the application.
            while (true)
            {
                User user;
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                    user = login.LoggedInUser;
                }

                var menu = new MainMenuForm(user);
                Application.Run(menu);

                if (!menu.LoggedOut) return;
            }
        }
    }
}
