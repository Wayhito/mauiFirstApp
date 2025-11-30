using mauiFirstApp;

namespace SimpleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Устанавливаем стартовую страницу
            MainPage = new MainPage();
        }
    }
}
