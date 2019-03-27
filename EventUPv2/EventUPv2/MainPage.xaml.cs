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

                VerifyUser(email.Text, pass.Text);
           
               

               
            

        }

        async void VerifyUser(string a, string b)
        {
            if (a == "User" && b == "user")
            {
                await Navigation.PushModalAsync(new HomePage());
            }
            else if (a == "Admin" && b == "admin") 
            {
                await Navigation.PushModalAsync(new HomePageAdmin());
            }
            else if (!string.IsNullOrEmpty(a) && a != "User" && a != "Admin")
            {
                await DisplayAlert("Alert", "E-mail non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(a))
            {
                await DisplayAlert("Alert", "E-mail non Inserita!", "OK");
            }
            else if (!string.IsNullOrEmpty(b) && b != "user" && a != "admin")
            {
                await DisplayAlert("Alert", "Password non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(b))
            {
                await DisplayAlert("Alert", "Password non Inserita!", "OK");
            }
        }


    }
}
