namespace ShopKvantorium;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            // ������������� �������� 3 �������
            await Task.Delay(15000);

            // �������� ����������� ������� ������
            var hasSavedCredentials = await CheckSavedCredentials();

            // ������� �� ��������������� ��������
            Application.Current.MainPage = new NavigationPage(
                hasSavedCredentials ? new AppShell() : new Reg()
            );
        }
        catch (Exception ex)
        {
            await DisplayAlert("������", ex.Message, "OK");
        }
    }

    private async Task<bool> CheckSavedCredentials()
    {
        var savedUsername = await SecureStorage.Default.GetAsync("username");
        var savedPassword = await SecureStorage.Default.GetAsync("password");

        if (string.IsNullOrEmpty(savedUsername)) return false;

        var users = UserService.GetUsers();
        return users.Any(u =>
            u.Username == savedUsername &&
            u.Password == savedPassword);
    }
}