using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using System.Linq;

using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

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
        public List<SelectableDataEvento<ExampleDataEvento>> SelectedDataEventiInCorso;
        public HomePage()
        {
            InitializeComponent();
            Utype.Text=Constants.CurrentUser.Cognome+" "+Constants.CurrentUser.Nome;
            Constants.listaEventi = listaEv;
            Constants.listaEventiCorso = listaEvIncorso;
            Constants.listaEventiStorico = listaEvPassati;
            SelectedDataEventi = new List<SelectableDataEvento<ExampleDataEvento>>();
            AssegnaEventi();
            AssegnaNews();
            for (int a = 0; a < listaEv.Count(); a++)
            {
                SelectableDataEvento<ExampleDataEvento> s;
                SelectedDataEventi.Add(s = new SelectableDataEvento<ExampleDataEvento>() { Data = new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo } });
               

            }
            BindingContext = new MultiSelectViewModelEvento(SelectedDataEventi);

            SelectedDataEventiInCorso = new List<SelectableDataEvento<ExampleDataEvento>>();
            AssegnaEventi();
            for (int a = 0; a < listaEvIncorso.Count(); a++)
            {
                SelectableDataEvento<ExampleDataEvento> s;
                SelectedDataEventiInCorso.Add(s = new SelectableDataEvento<ExampleDataEvento>() { Data = new ExampleDataEvento() { Titolo = listaEvIncorso.ElementAt(a).Titolo } });


            }
            BindingContext = new MultiSelectViewModelEvento(SelectedDataEventiInCorso);



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

            await Navigation.PushAsync(new PageEventi(eventiList.SelectedItem.ToString()));

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

        async void FilterButton(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new FiltriPopupPage());

        }
        async void interest(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new RegistratiInteressi());

        }
        async Task AssegnaEventi()
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
            Constants.listaEventiAzienda = listaEvIncorso//utilizzato solo per esempio
        }
        async Task AssegnaNews()
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
