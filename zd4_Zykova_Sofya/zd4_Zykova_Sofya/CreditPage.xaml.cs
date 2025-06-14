using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd4_Zykova_Sofya
{
    public partial class CreditPage : ContentPage
    {
        public CreditPage()
        {
           
            InitializeComponent();

           
        }

        public string Username { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrEmpty(Username))
            {
                WelcomeLabel.Text = $"Welcome, {Username}!";
            }
        }
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(amountEntry.Text, out double amount)) 
                    return;
                if (!int.TryParse(termPicker.SelectedItem?.ToString(), out int term)) 
                    return;
                if (!double.TryParse(rateEntry.Text, out double rate)) 
                    return;

                bool isAnnuity = paymentTypePicker.SelectedIndex == 0;

                if (isAnnuity)
                {
                    // Расчет аннуитетного платежа
                    double monthlyRate = rate / 1200;
                    double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, term)) /
                                       (Math.Pow(1 + monthlyRate, term) - 1);
                    double monthlyPayment = amount * coefficient;

                    monthlyPaymentLabel.Text = $"Ежемесячный платеж: {monthlyPayment:F2} ₽";
                    totalPaymentLabel.Text = $"Общая сумма: {monthlyPayment * term:F2} ₽";
                    overpaymentLabel.Text = $"Переплата: {monthlyPayment * term - amount:F2} ₽";
                }
                else
                {
                    // Дифференцированный расчет
                    double principal = amount / term;
                    double totalPayment = 0;

                    for (int i = 0; i < term; i++)
                    {
                        double remaining = amount - (principal * i);
                        totalPayment += principal + (remaining * rate / 12);
                    }

                    double overpayment = totalPayment - amount;

                    monthlyPaymentLabel.IsVisible = false;
                    totalPaymentLabel.Text = $"Общая сумма: {totalPayment:F2} ₽";
                    overpaymentLabel.Text = $"Переплата: {overpayment:F2} ₽";
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", "Проверьте введенные данные", "OK");
            }
        }
    }
}
