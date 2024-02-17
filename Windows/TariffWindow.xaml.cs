using REST_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace REST_Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для TariffWindow.xaml
    /// </summary>
    public partial class TariffWindow : Window
    {
        private MainWindow parent;
        private Responce response;
        private HttpClient client;
        private Tariff? tariff;

        public TariffWindow(Responce response, MainWindow autorize)
        {
            InitializeComponent();
            parent = autorize;
            this.response = response;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + response.access_token);
            Task.Run(() => Load());

        }

        private async void Load()
        {
            //List<Sales>? list = await client.GetFromJsonAsync<List<Sales>>("http://localhost:5174/api/sales");
            //foreach (Sales i in list!)
            //{
            //    i.PriceList = await client.GetFromJsonAsync<PriceList>("http://localhost:5174/api/pricelist/" + i.PriceList_Id);
            //}
            //Dispatcher.Invoke(() =>
            //{
            //    SalesList.ItemsSource = null;
            //    SalesList.Items.Clear();
            //    SalesList.ItemsSource = list;
            //});

            List<Tariff>? list = await client.GetFromJsonAsync <List<Tariff>>("http://localhost:5247/api/tariff");
            Dispatcher.Invoke(() =>
            {
                TariffList.ItemsSource = null;
                TariffList.Items.Clear();
                TariffList.ItemsSource = list;
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        //private async Task Save(Tariff tariff)
        //{
        //    JsonContent content = JsonContent.Create(tariff);
        //    using var response = await client.PostAsync("http://localhost:5247/api/tariff", content);
        //    string responseText = await response.Content.ReadAsStringAsync();
        //    await Load();
        //}
        //private async Task Delete()
        //{
        //    using var response = await client.DeleteAsync("http://localhost:5247/api/tariff" + tariff?.Id);
        //    string responseText = await response.Content.ReadAsStringAsync();
        //    await Load();
        //}
        //private async Task Edit(Tariff tariff)
        //{
        //    JsonContent content = JsonContent.Create(tariff);
        //    using var response = await client.PutAsync("http://localhost:5247/api/tariff", content);
        //    string responseText = await response.Content.ReadAsStringAsync();
        //    await Load();
        //}
    }
}
