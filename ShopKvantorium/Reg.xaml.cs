using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Text;

namespace ShopKvantorium;

public partial class Reg : ContentPage
{
	public Reg()
	{
		InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var login = LoginEntry.Text;
        var password = PasswordEntry.Text;

        bool isAuthenticated = await AuthenticateUser(login, password);

        if (isAuthenticated)
        {
            Preferences.Set("login", login);
            Preferences.Set("password", password);

            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Ошибка", "Неверный логин или пароль", "Ок");
        }
    }


    private async Task<bool> AuthenticateUser(string login, string password)
    {

        var client = new HttpClient();
        var url = "https://node-server-1-7yyx.onrender.com/auth";

        var data = new
        {
            login = login,
            password = password
        };

        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        return response.IsSuccessStatusCode;

    }
}