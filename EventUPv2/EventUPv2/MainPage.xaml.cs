using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace EventUPv2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        async void OnRegisterClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Alert", pass.Text, "OK");
            await Navigation.PushModalAsync(new Registrati());


        }
        void OnLoginClicked(object sender, EventArgs args)
        {
             Verify(email.Text, "Pippo", pass.Text, "peppo");


        }

        async void Verify(string a, string b, string c, string d)
        {
            if (a == b && c == d)
            {
                await Navigation.PushModalAsync(new HomePage());
            }
            else if (!string.IsNullOrEmpty(a) && a != b)
            {
                await DisplayAlert("Alert", "E-mail non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(a))
            {
                await DisplayAlert("Alert", "E-mail non Inserita!", "OK");
            }
            else if (!string.IsNullOrEmpty(c) && c != d)
            {
                await DisplayAlert("Alert", "Password non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(c))
            {
                await DisplayAlert("Alert", "Password non Inserita!", "OK");
            }
        }

    }
}
