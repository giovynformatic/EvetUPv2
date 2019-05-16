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
        public List<Admin> listaAziende;
        public List<Evento> listaEv;
        public List<Evento> listaEvIncorso;
        public List<Evento> listaEvPassati;
        public List<News> listaNews;
        public List<SelectableDataEvento<ExampleDataEvento>> SelectedDataEventi;
        public List<SelectableDataEventoIncorso<ExampleDataEvento>> SelectedDataEventiInCorso;
        public List<SeletableDataEventoPassato<ExampleDataEvento>> SelectedDataEventiPassati;
        public List<SelectableDataNews<ExampleDataNews>> SelectedDataNews;
        public HomePage()
        {
            InitializeComponent();
            Utype.Text=Constants.CurrentUser.Cognome+" "+Constants.CurrentUser.Nome;
            Constants.listaEventi = listaEv;
            Constants.listaEventiCorso = listaEvIncorso;
            Constants.listaEventiStorico = listaEvPassati;
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
            

            SelectedDataEventiInCorso = new List<SelectableDataEventoIncorso<ExampleDataEvento>>();

            for (int a = 0; a < listaEvIncorso.Count(); a++)
            {
                SelectableDataEventoIncorso<ExampleDataEvento> s;
                SelectedDataEventiInCorso.Add(s = new SelectableDataEventoIncorso<ExampleDataEvento>() { Data1 = new ExampleDataEvento() { Titolo = listaEvIncorso.ElementAt(a).Titolo } });


            }

            currenteventiList.BindingContext = new MultiSelectViewModelEventoIncorso(SelectedDataEventiInCorso);

            SelectedDataEventiPassati = new List<SeletableDataEventoPassato<ExampleDataEvento>>();
           
            for (int a = 0; a < listaEvPassati.Count(); a++)
            {
                SeletableDataEventoPassato<ExampleDataEvento> s;
                SelectedDataEventiPassati.Add(s = new SeletableDataEventoPassato<ExampleDataEvento>() { Data2 = new ExampleDataEvento() { Titolo = listaEvPassati.ElementAt(a).Titolo } });


            }

            pasteventiList.BindingContext = new MultiSelectViewModelEventoPassato(SelectedDataEventiPassati);
            
            SelectedDataNews = new List<SelectableDataNews<ExampleDataNews>>();

            for (int a = 0; a < listaNews.Count(); a++)
            {
                SelectableDataNews<ExampleDataNews> s;
                SelectedDataNews.Add(s = new SelectableDataNews<ExampleDataNews>() { Data3 = new ExampleDataNews() { Titolo = listaNews.ElementAt(a).Titolo } });


            }
            newsList.BindingContext = new MultiSelectViewModelNews(SelectedDataNews);


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
            var mydetails = e.Item as Evento;
            await Navigation.PushAsync(new PageEventi(mydetails.Titolo,1));

        }
        async void EventoInCorso(object sender, EventArgs args)
        {
            AssegnaEventi();
            await Navigation.PushAsync(new PageEventi("",2));

        }
        async void EventoPassati(object sender, EventArgs args)
        {
            AssegnaEventi();
            await Navigation.PushAsync(new PageEventi("",3));

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
            byte[] im = null;
            var ev1 = new Evento("Corso Cisco", "25/05/2019", im, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var ev2 = new Evento("Crazyland", "13/06/2019", im, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var ev3 = new Evento("Medimex", "15/11/2019", im, "Puglia Records", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            listaEv.Add(ev1);
            listaEv.Add(ev2);
            listaEv.Add(ev3);
            listaEvIncorso.Add(ev1);
            listaEvIncorso.Add(ev2);
            //  listaEvIncorso.Add(ev3);
            listaEvPassati.Add(ev1);
            listaEvPassati.Add(ev2);
            listaEvPassati.Add(ev3);
            Constants.listaEventi = listaEv;
            Constants.listaEventiCorso = listaEvIncorso;
            Constants.listaEventiStorico = listaEvPassati;
            Constants.listaEventiAzienda = listaEvIncorso;//utilizzato solo per esempio
        }
        public void AssegnaNews()
        {
            //codice utilizzato per app senza back end
            listaNews = new List<News>();

            byte[] im = null;
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
