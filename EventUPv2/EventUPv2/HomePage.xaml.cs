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
            Utype.Text=Constants.CurrentUser.Cognome+" "+Constants.CurrentUser.Nome;
        }
        public void datiAnagrafici(object sender, EventArgs args) {

            
            PopupNavigation.Instance.PushAsync(new PopupTaskView());

        }
        public void gestionePassword(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new GestionePasswordPopup());

        }
        public void qrPage(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new QrCodePopup());

        }
        async void aziende(object sender, EventArgs args)
        {

            await Navigation.PushModalAsync(new SelectAziende());

        }

    }
}
