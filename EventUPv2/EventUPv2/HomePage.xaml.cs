using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using System.Linq;

using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using XLabs.Forms;

namespace EventUPv2
{

    public partial class HomePage : TabbedPage
    {
        
        public List<Evento> listaEv;
        public List<Evento> listaEvIncorso;
        public List<Evento> listaEvPassati;
        public List<News> listaNews;
    //    public List<SelectableDataEvento<ExampleDataEvento>> SelectedDataEventi;
    
        public HomePage()
        {
            InitializeComponent();
            Utype.Text=Constants.CurrentUser.Cognome+" "+Constants.CurrentUser.Nome;
           // SelectedDataEventi = new List<SelectableDataEvento<ExampleDataEvento>>();
            AssegnaEventi();
            AssegnaNews();
          /*  for (int a = 0; a < listaEv.Count(); a++)
            {
                SelectableDataEvento<ExampleDataEvento> s;
                SelectedDataEventi.Add(s = new SelectableDataEvento<ExampleDataEvento>() { Data = new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo } });
               

            }*/
           // eventiList.BindingContext= new MultiSelectViewModelEvento(SelectedDataEventi);

            eventiList.BindingContext= new MultiSelectViewModelEvento();
            currenteventiList.BindingContext = new MultiSelectViewModelEventoIncorso();
            pasteventiList.BindingContext = new MultiSelectViewModelEventoPassato();
            newsList.BindingContext = new MultiSelectViewModelNews();


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

        async void Evento(object sender, ItemTappedEventArgs e)
        {
            AssegnaEventi();
            //  String cc = eventiList.SelectedItem.ToString();
            //   Console.WriteLine(eventiList.ItemSel);
            var evento = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(evento.Titolo,evento.Descrizione,evento.Data,evento.Azienda,evento.Immagine,1));

        }
        async void EventoInCorso(object sender, ItemTappedEventArgs e)
        {
            AssegnaEventi();
            var eventoInCorso = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(eventoInCorso.Titolo, eventoInCorso.Descrizione, eventoInCorso.Data, eventoInCorso.Azienda, eventoInCorso.Immagine, 2));

        }
        async void EventoPassati(object sender, ItemTappedEventArgs e)
        {
            AssegnaEventi();
            var eventoPassati = e.Item as ExampleDataEvento;
            await Navigation.PushAsync(new PageEventi(eventoPassati.Titolo, eventoPassati.Descrizione, eventoPassati.Data, eventoPassati.Azienda, eventoPassati.Immagine, 3));

        }


        async void News(object sender, ItemTappedEventArgs e)
        {
            var news = e.Item as ExampleDataNews;
            await Navigation.PushAsync(new PageNews(news.Titolo,news.Descrizione,news.Data,news.Azienda,news.Immagine));

        }

        async void searchButtonEv(object sender, EventArgs args)
        {
            if (searchEv.Text != "" && searchEv.Text != null){
                await DisplayAlert("Alert", searchEv.Text, "ok");
            }else {
                await DisplayAlert("Alert", "nessun testo inserito", "ok");
            }
        }
        async void searchButtonEvCur(object sender, EventArgs args)
        {
            if (searchcurrentEv.Text != "" && searchcurrentEv.Text != null)
            {
                await DisplayAlert("Alert", searchcurrentEv.Text, "ok");
            }
            else
            {
                await DisplayAlert("Alert", "nessun testo inserito", "ok");
            }
        }
        async void searchButtonEvPast(object sender, EventArgs args)
        {
            if (searchpastEv.Text != "" && searchpastEv.Text != null)
            {
                await DisplayAlert("Alert", searchpastEv.Text, "ok");
            }
            else
            {
                await DisplayAlert("Alert", "nessun testo inserito", "ok");
            }
        }

        async void searchButtonNews(object sender, EventArgs args)
        {
            if (searchNews.Text != "" && searchNews.Text != null)
            {
                await DisplayAlert("Alert", searchNews.Text, "ok");
            }
            else
            {
                await DisplayAlert("Alert", "nessun testo inserito", "ok");
            }
        }
        async void menuButton(object sender, EventArgs args)
        {

            await DisplayAlert("Alert", "menu", "ok");

        }

        public void FilterButton(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new FiltriPopupPage());

        }
        async void interest(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new RegistratiInteressi());

        }

        public void AssegnaEventi()
        {
            //codice utilizzato per app senza back end
            listaEv = new List<Evento>();
            listaEvIncorso = new List<Evento>();
            listaEvPassati = new List<Evento>();
            String im = "https://png.icons8.com/car/ultraviolet/50/3498db";
            var ev1 = new Evento("Corso Cisco", "25/05/2019", im, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf", true, false, false);
            var ev2 = new Evento("Crazyland", "13/06/2019", im, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf", false, false, true);
            var ev3 = new Evento("Medimex", "15/11/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf", false, true, false);
            var ev4 = new Evento("ZeroFest", "25/05/2019", im, "Puglia Records", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf", true, false, false);
            listaEv.Add(ev1);
            listaEv.Add(ev4);
            listaEvIncorso.Add(ev2);
            listaEvPassati.Add(ev3);
            Constants.listaEventi = listaEv;
            Constants.listaEventiCorso = listaEvIncorso;
            Constants.listaEventiStorico = listaEvPassati;
            
        }
        public void AssegnaNews()
        {
            //codice utilizzato per app senza back end
            listaNews = new List<News>();

            String im = null;
            var n1 = new News("Evento!!!", "25/05/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var n2 = new News("Secondo evento!!!", "13/06/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var n3 = new News("Terzo evento!!!", "15/11/2019", im, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            listaNews.Add(n1);
            listaNews.Add(n2);
            listaNews.Add(n3);
            Constants.listaNews = listaNews;

        }
    }
}
