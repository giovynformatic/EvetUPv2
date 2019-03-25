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

    }
}
