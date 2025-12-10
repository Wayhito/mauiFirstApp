using System.Net.Http.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private HttpClient _httpClient = new HttpClient();
        private string _currentImageSource = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var response = await _httpClient
                .GetFromJsonAsync<DogResponse>("https://dog.ceo/api/breeds/image/random");
            if (response != null)
            {
                DogImage.Source = response.Message;
                _currentImageSource = response.Message;
            }
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await AndroidImageSaver.SaveImageFromUrlToGalleryAsync(_currentImageSource, "dog" + Guid.NewGuid());
            }
            catch (Exception ex)
            {
                SaveResultLabel.Text = "Не получилось сохранить";
                return;
            }
            SaveResultLabel.Text = "Сохранено";
        }

        public class DogResponse
        {
            public string? Message { get; set; }
            public string? Status { get; set; }
        }
    }
}