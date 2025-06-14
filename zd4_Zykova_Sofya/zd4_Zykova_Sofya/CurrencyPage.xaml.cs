using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd4_Zykova_Sofya
{
    public partial class CurrencyPage : ContentPage
    {
        public CurrencyPage()
        {
           
            InitializeComponent();
            LoadRates();

        }

        private void LoadRates()
        {
            // Здесь можно реализовать загрузку реальных курсов с API
            dateLabel.Text = DateTime.Now.ToString("dd.MM.yyyy");
            usdLabel.Text = "75.50 ₽";
            eurLabel.Text = "85.30 ₽";
        }

        private void OnUpdateRatesClicked(object sender, EventArgs e)
        {
            LoadRates();
            DisplayAlert("Обновлено", "Курсы валют обновлены", "OK");
        }
    }
}
