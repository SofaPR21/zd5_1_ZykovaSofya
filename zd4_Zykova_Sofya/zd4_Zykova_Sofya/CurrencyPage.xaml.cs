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

        private async void OnUpdateRatesClicked(object sender, EventArgs e)
        {
            try
            {
                // Здесь может быть вызов API
                dateLabel.Text = DateTime.Now.ToString("dd.MM.yyyy");
                usdLabel.Text = "75.50 ₽";
                eurLabel.Text = "85.30 ₽";

                await DisplayAlert("Успех", "Курсы обновлены", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
