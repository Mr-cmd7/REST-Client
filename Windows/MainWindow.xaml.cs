using REST_Client.Models;
using REST_Client.Windows;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace REST_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User { Email = Login.Text,Password=Password.Password };
            JsonContent content = JsonContent.Create(user);
            using var response = await client.PostAsync("http://localhost:5247/login",content);
            string responseText = await response.Content.ReadAsStringAsync();
            Responce? resp = JsonSerializer.Deserialize<Responce?>(responseText);
            if (resp != null)
            {
                TariffWindow tariffs = new TariffWindow(resp, this);
                tariffs.Show(); 
                Hide();
            }

        }
    }
}