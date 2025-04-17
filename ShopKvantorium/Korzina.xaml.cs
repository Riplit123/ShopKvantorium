namespace ShopKvantorium;

public partial class Korzina : ContentPage
{
	public Korzina()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}