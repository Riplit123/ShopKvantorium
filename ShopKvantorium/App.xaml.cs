using Newtonsoft.Json;
using System.Text;

namespace ShopKvantorium
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

     /* protected override async void OnStart()
       {

          bool isLoggedIn = await IsUserLoggedIn();

           if (isLoggedIn)
           {
               if (isLoggedIn)
              {
                  string direction = Preferences.Get("userDirection", string.Empty);

                   switch (direction)
                    {
                        case "programming":
                            MainPage = new NavigationPage(new AppShell());
                            break;
                        case "robotics":
                            MainPage = new NavigationPage(new AppShell());
                            break;
                        case "journalism":
                            MainPage = new NavigationPage(new AppShell());
                            break;
                    }
                }
            }
            else
            {
                MainPage = new NavigationPage(new Reg());
            }
        }

        private async Task<bool> IsUserLoggedIn()
        {
            string token = Preferences.Get("authToken", null);

            if (string.IsNullOrEmpty(token))
                return false;

            try
            {
                var client = new HttpClient();
                var url = "https://node-server-1-7yyx.onrender.com/verify-token";

                var data = new { token };
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    return result.success == true;
                }
            }
            catch
            {

            }

            return false;
        } */




    }
}
