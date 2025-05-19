
using Newtonsoft.Json;
using System.Text;

namespace ShopKvantorium
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoadingPage();
            InitializeApp();
        }

        private async void InitializeApp()
        {
            try
            {
                var hasSavedCredentials = await CheckSavedCredentials();

                MainPage = new NavigationPage(
                    hasSavedCredentials
                        ? new AppShell()
                        : new Reg()
                );
            }
            catch (Exception ex)
            {
                //MainPage = new ErrorPage(ex.Message);
            }
        }

        private async Task<bool> CheckSavedCredentials()
        {
            var savedUsername = await SecureStorage.Default.GetAsync("username");
            var savedPassword = await SecureStorage.Default.GetAsync("password");

            if (string.IsNullOrEmpty(savedUsername) ||
                string.IsNullOrEmpty(savedPassword))
                return false;

            var users = UserService.GetUsers();
            return users.Any(u =>
                u.Username == savedUsername &&
                u.Password == savedPassword);
        }




    }
}
