namespace ShopKvantorium;

public partial class PoiskS : ContentPage
{
	public PoiskS()
	{
		InitializeComponent();
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}