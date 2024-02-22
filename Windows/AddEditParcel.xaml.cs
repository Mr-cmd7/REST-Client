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
    /// Логика взаимодействия для AddEditParcel.xaml
    /// </summary>
    public partial class AddEditParcel : Window
    {
        private Responce responce;
        private HttpClient client;
        private List<Parcel>? list;
        public AddEditParcel(Responce responce)
        {
            InitializeComponent();
            this.responce = responce;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + responce.access_token);
            Load_Codes();
            Task.Run(() => Load());
         
        }
        private async void Load_Codes()
        {
            List<Tariff>? list = await client.GetFromJsonAsync<List<Tariff>>("http://localhost:5174/api/tariff");
            foreach(var i in list)
            {
                cbDepartureCode.Items.Add(i.DepartureCode);
            }
        }

        private async Task Load()
        {
          
        }

        private void cbMarka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbDiscounr_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        public string SenderFullName
        {
            get
            {
                return FIO.Text;
            }
            set
            {
                FIO.Text = value;
            }
        }
        public string DepartureCode
        {
            get;
            set;
        }
    }
}
