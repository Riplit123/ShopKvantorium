using Newtonsoft.Json;
using System.Text;

namespace ShopKvantorium;

public partial class AkauntS : ContentPage
{

    private string _login;
    public AkauntS()
    {
        InitializeComponent();


        ShowMoney();
    }

    private async void ShowMoney()
    {
        try
        {
            var client = new HttpClient();
            var url = "https://node-server-1-7yyx.onrender.com/get-state";

            var data = new
            {
                login = _login

            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                if (result.Success)
                {

                }
                else
                {

                }

            }
            else
            {
                await DisplayAlert("Успех", "Вам начислен Кванторик за участие в мероприятии", null, "Ок");
                kvantoriki.Text = "2";

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", "43534435", "4353454", "7789");


        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Profil());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Sorevnovania());
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new PoiskS());
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Meropriatia());
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new AkauntS());
    }

    private async void Button_Clicked_5(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}