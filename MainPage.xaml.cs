using System.Net.Http.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private HttpClient _httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var response = await _httpClient
                .GetFromJsonAsync<DogResponse>("https://dog.ceo/api/breeds/image/random");

            DogImage.Source = response.Message;
        }
    }

    public class DogResponse
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }
}