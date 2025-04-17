using Newtonsoft.Json;
using System.Text;

namespace ShopKvantorium;

public partial class Sorevnovania : ContentPage

{
        private string _login;
        public Sorevnovania()
        {
            InitializeComponent();
        }
    
   private async void Button_Clicked(object sender, EventArgs e)
   {
       var result = await DisplayAlert("����� ������", "������ ���������� �� �����������?", "��", "���");
       if (result == true) // ���� ������ ������ "��"
       {
           var client = new HttpClient();
           var url = "https://node-server-1-7yyx.onrender.com/update-state";

           var data = new
           {
               login = _login
           };
           var json = JsonConvert.SerializeObject(data);
           var content = new StringContent(json, Encoding.UTF8, "application/json");
           var response = await client.PostAsync(url, content);

           if (response.IsSuccessStatusCode)
           {
               await DisplayAlert("����������", "��� �������� 1 ���������, � ����� �� ���� ��������� � ��� ����������", "��", "�������");
           }
           else
           {
               await DisplayAlert("��������", "��� �������� 1 ���������, � ����� �� ���� ��������� � ��� ����������", "��", "�������");
           }
       }

   }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }
}
