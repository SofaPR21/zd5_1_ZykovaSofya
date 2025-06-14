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

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(amountEntry.Text);
                int term = Convert.ToInt32(termPicker.SelectedItem.ToString());
                double rate = Convert.ToDouble(rateEntry.Text) / 100;
                bool isAnnuity = paymentTypePicker.SelectedIndex == 0;

                if (isAnnuity)
                {
                    // Аннуитетный расчет
                    double monthlyRate = rate / 12;
                    double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, term)) /
                                        (Math.Pow(1 + monthlyRate, term) - 1);
                    double monthlyPayment = amount * coefficient;
                    double totalPayment = monthlyPayment * term;
                    double overpayment = totalPayment - amount;

                    monthlyPaymentLabel.Text = $"Ежемесячный платеж: {monthlyPayment:F2} ₽";
                    monthlyPaymentLabel.IsVisible = true;
                    totalPaymentLabel.Text = $"Общая сумма: {totalPayment:F2} ₽";
                    overpaymentLabel.Text = $"Переплата: {overpayment:F2} ₽";
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
