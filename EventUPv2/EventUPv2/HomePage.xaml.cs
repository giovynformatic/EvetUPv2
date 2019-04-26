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

            await Navigation.PushAsync(new SelectAziende());

        }

        async void Evento(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new PageEventi());

        }

        async void News(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new PageNews());

        }
        async void searchButton(object sender, EventArgs args)
        {
            if (search.Text != "" && search.Text != null){
                await DisplayAlert("Alert", search.Text, "ok");
            }else {
                await DisplayAlert("Alert", "nessun testo inserito", "ok");
            }
        }
        async void menuButton(object sender, EventArgs args)
        {

            await DisplayAlert("Alert", "menu", "ok");

        }

        async void interest(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new RegistratiInteressi());

        }

    }
}
