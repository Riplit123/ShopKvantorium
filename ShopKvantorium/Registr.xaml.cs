
namespace ShopKvantorium;

public partial class Registr : ContentPage
{
	public Registr()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Ошибка", "Пароли не совпадают", "OK");
            return;
        }

        var users = UserService.GetUsers();

        if (users.Any(u => u.Username == UsernameEntry.Text))
        {
            await DisplayAlert("Ошибка", "Пользователь уже существует", "OK");
            return;
        }

        var newUser = new User
        {
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        };

        users.Add(newUser);
        UserService.SaveUsers(users);

        await DisplayAlert("Успех", "Регистрация прошла успешно", "OK");
        await Navigation.PopAsync();
    }
}