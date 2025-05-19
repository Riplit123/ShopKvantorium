
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
            await DisplayAlert("������", "������ �� ���������", "OK");
            return;
        }

        var users = UserService.GetUsers();

        if (users.Any(u => u.Username == UsernameEntry.Text))
        {
            await DisplayAlert("������", "������������ ��� ����������", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(FionameEntry.Text))
        {
            await DisplayAlert("������", "������� ���", "OK");
            return;
        }

        var newUser = new User
        {
            Fioname = FionameEntry.Text,
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        };

        users.Add(newUser);
        UserService.SaveUsers(users);
        await SecureStorage.SetAsync("fullname", newUser.Fioname);

        await DisplayAlert("�����", "����������� ������ �������", "OK");
        await Navigation.PopAsync();
    }
}