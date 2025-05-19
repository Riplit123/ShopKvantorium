
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
        try
        {
            var users = UserService.GetUsers();
            var user = users.FirstOrDefault(u =>
                u.Username == LoginEntry.Text &&
                u.Password == PasswordEntry.Text);

            if (user != null)
            {
                await SecureStorage.Default.SetAsync("username", user.Username);
                await SecureStorage.Default.SetAsync("password", user.Password);

                Application.Current.MainPage = new NavigationPage(new AppShell());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверные данные", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }


    

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registr());
    }
}