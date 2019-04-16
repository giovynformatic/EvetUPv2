using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace EventUPv2
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();

        }
        public void datiAnagrafici(object sender, EventArgs args) {

            
            PopupNavigation.Instance.PushAsync(new PopupTaskView());

        }
        async void gestionePassword(object sender, EventArgs args)
        {

            await DisplayAlert("OK", "page password", "OK");

        }
        async void qrPage(object sender, EventArgs args)
        {

            await DisplayAlert("OK", "page qr", "OK");

        }

    }
}
