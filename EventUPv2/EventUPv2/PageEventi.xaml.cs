using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PageEventi : ContentPage
    {
        public PageEventi(string title,string description, string date , string factory, string image ,int tipo)
        {
            InitializeComponent();
            titolo.Text = title;
            descrizione.Text = description;
            data.Text = date;
            azienda.Text = factory;
            immagine.Source = image;

            switch (tipo) {
                case 1:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = true;
                    Partecipanti.IsVisible = false;
                    Partecipanti.IsEnabled = false;
                    partecipa.Clicked += Partecipa_Clicked;
                    partecipa.Text = "Partecipa";
                    break;
                case 2:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = false;
                    Partecipanti.IsVisible = false;
                    Partecipanti.IsEnabled = false;
                    partecipa.Clicked += Partecipa_Clicked;
                    partecipa.Text = "Gia Iscritto a Quest'Evento";
                    break;
                case 3:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = false;
                    Partecipanti.IsVisible = false;
                    Partecipanti.IsEnabled = false;
                    partecipa.Text = "Evento Scaduto";
                    partecipa.Clicked += Partecipa_Clicked;
                    break;
                case 4:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = true;
                    Partecipanti.IsVisible = true;
                    Partecipanti.IsEnabled = true;
                    partecipa.Text = "Prendi Presenza";
                    Partecipanti.Text = "Partecipanti";
                    partecipa.Clicked += OpenScanner;
                    Partecipanti.Clicked += Partecipanti_Clicked;
                    break;

                case 5:
                    partecipa.IsVisible = false;
                    partecipa.IsEnabled = false;
                    Partecipanti.IsVisible = true;
                    Partecipanti.IsEnabled = true;
                    partecipa.Text = "Prendi Presenza";
                    Partecipanti.Text = "Partecipanti";
                    partecipa.Clicked += OpenScanner;
                    Partecipanti.Clicked += Partecipanti_Clicked;
                    break;

            }



        }

        async void Partecipa_Clicked(object sender, EventArgs e)
        {
            //     await App.ParManager.SaveTaskAsync(Constants.CurrentUser.email+"-"+titolo.Text);
            await DisplayAlert("Alert", Constants.CurrentUser.email + "-" + titolo.Text, "ok");
        }

        async void Partecipanti_Clicked(object sender, EventArgs e)
        {

             PopupNavigation.Instance.PushAsync(new Popup_Partecipanti()); 
           
        }

        async void OpenScanner(object sender, EventArgs e)
        {
          
            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                Device.BeginInvokeOnMainThread(async () => {
                    Navigation.PopAsync();
                    //await App.PrManager.SaveTaskAsync(result.Text);
                    DisplayAlert("Codice scannerizzato", result.Text + "-" + titolo.Text, "OK");
                });
            };


            await Navigation.PushAsync(ScannerPage);
        }

       
    }
}
