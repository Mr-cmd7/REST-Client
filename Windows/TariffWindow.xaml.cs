using REST_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
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
        private Responce response;
        private HttpClient client;
        private Tariff? list;

        public TariffWindow(Responce response,MainWindow mw)
        {
            InitializeComponent();
            this.response = response;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + response.access_token);
            Task.Run(() => Load());

        }
        private async Task Load()
        {
            //HFCVJNHTNM
            List<Tariff>? list = await client.GetFromJsonAsync<List<Tariff>>("http://localhost:7152/api/tariff");
            Dispatcher.Invoke(() =>
            {
                ListPrice.ItemsSource = null;
                ListPrice.Items.Clear();
                ListPrice.ItemsSource = list;
            });
        }
        private async Task Save()
        {
            Tariff tariif = new Tariff
            {
                DepartureCode = DepartureCode.Text,
                DepartureName = DepartureName.Text,
                PricePerWeightUnit = decimal.Parse(PricePerWeightUnit.Text)
            };
            JsonContent content = JsonContent.Create(tariif);
            using var response = await client.PostAsync("http://localhost:7152/api/tariff", content);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Save();
        }

        private async Task Edit()
        {
            list!.DepartureCode = DepartureCode.Text;
            list!.DepartureName = DepartureName.Text;
            list!.PricePerWeightUnit = decimal.Parse(PricePerWeightUnit.Text);
            JsonContent content = JsonContent.Create(list);
            using var response = await client.PutAsync("http://localhost:7152/api/tariff", content);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            await Edit();
        }
        private async Task Delete()
        {
            using var response = await client.DeleteAsync("http://localhost:7152/api/tariff/" + list?.Id);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private async void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            await Delete();
        }
        private void ListTariff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list = ListPrice.SelectedItem as Tariff;
            DepartureCode.Text = list?.DepartureCode;
            DepartureName.Text = list?.DepartureName;
            PricePerWeightUnit.Text = list?.PricePerWeightUnit.ToString();
        }
    }
}
