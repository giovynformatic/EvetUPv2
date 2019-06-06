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
        public List<Evento> listaEvAz;
        public List<News> listaNewsAz;
        public HomePageAdmin ()
        {

            InitializeComponent();
            listaEvAz = Constants.listaEventiAzienda;
            listaNewsAz = Constants.listaNewsAzienda;
            Utype.Text = Constants.CurrentAdmin.NomeAzienda;
            eventiAziendaList.BindingContext = new MultiSelectViewModelEventoAzienda();
            newsList.BindingContext = new MultiSelectViewModelNewsAzienda();
            eventiAziendaListincorso.BindingContext = new MultiSelectViewModelEventoIncorsoAzienda();
            eventiAziendaListpassato.BindingContext = new MultiSelectViewModelEventoPassatoAzienda();

        }
        public void datiAzienda(object sender, EventArgs args)
        {


            PopupNavigation.Instance.PushAsync(new PopupTaskViewAzienda());

        }
        async void EventoAzienda(object sender, ItemTappedEventArgs e)
        {
            var evento = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(evento.Titolo, evento.Descrizione, evento.Data, evento.Azienda, evento.Immagine, 5));

        }

        async void EventoAziendaInCorso(object sender, ItemTappedEventArgs e)
        {
            var evento = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(evento.Titolo, evento.Descrizione, evento.Data, evento.Azienda, evento.Immagine, 4));

        }

        async void EventoAziendaPassato(object sender, ItemTappedEventArgs e)
        {
            var evento = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(evento.Titolo, evento.Descrizione, evento.Data, evento.Azienda, evento.Immagine, 5));

        }

        async void News(object sender, ItemTappedEventArgs e)
        {
            var news = e.Item as ExampleDataNews;
            await Navigation.PushAsync(new PageNews(news.Titolo, news.Descrizione, news.Data, news.Azienda, news.Immagine));

        }
        public void gestionePasswordAzienda(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new GestionePasswordPopupAzienda());

        }
       /* private void OpenScanner(object sender, EventArgs e)
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
                Device.BeginInvokeOnMainThread(async () => {
                    Navigation.PopAsync();
                    //await App.PrManager.SaveTaskAsync(result.Text);
                    DisplayAlert("Codice scannerizzato", result.Text, "OK");
                });
            };


            await Navigation.PushAsync(ScannerPage);

        }
        */
    }
}