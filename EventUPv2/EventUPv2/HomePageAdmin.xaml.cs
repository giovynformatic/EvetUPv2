using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageAdmin : TabbedPage
    {
        public HomePageAdmin ()
        {
            InitializeComponent();
            Utype.Text = Constants.CurrentAdmin.NomeAzienda;
        }
        public void datiAzienda(object sender, EventArgs args)
        {


            PopupNavigation.Instance.PushAsync(new PopupTaskViewAzienda());

        }
        public void gestionePasswordAzienda(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new GestionePasswordPopupAzienda());

        }
        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner();
        }

        public async void Scanner()
        {

            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Codice scannerizzato", result.Text, "OK");
                });
            };


            await Navigation.PushAsync(ScannerPage);

        }

    }
}