namespace ShopKvantorium;

public partial class Profil : ContentPage
{
	public Profil()
	{
		InitializeComponent();
        OnPageLoaded();

    }

    private async void OnPageLoaded()
    {
        try
        {
            var username = await SecureStorage.Default.GetAsync("username");
            var fullName = await SecureStorage.GetAsync("fullname");
            Fio.Text = string.IsNullOrEmpty(fullName)
                ? fullName
                : $"{fullName}";
            Nik.Text = string.IsNullOrEmpty(username)
                ? fullName
                : $"@{username}";
        }
        catch (Exception ex)
        {
            Nik.Text = "Ошибка загрузки данных";
            Console.WriteLine($"Error loading username: {ex.Message}");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        SecureStorage.Remove("username");
        SecureStorage.Remove("password");
        await Navigation.PushAsync(new Reg());
        Navigation.RemovePage(this);
    }

    

    private void Button_Clicked_2(object sender, EventArgs e)
    {

    }
}