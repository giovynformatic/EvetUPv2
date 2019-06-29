using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EventUPv2
{
    public partial class MainPage : TabbedPage
    {
        public List<User> listaUtenti;
        public List<Admin> listaAziende;
        public List<Evento> listaEv;
        public List<Evento> listaEvIncorso;
        public List<Evento> listaEvPassati;
        public List<News> listaNews;
        public List<News> listaNewsAz;
        public List<Evento> listaEvAz;
        public MainPage()
        {
            InitializeComponent();
            AssegnaNews();
            newsList.BindingContext = new MultiSelectViewModelNews();
        }
        async void OnRegisterUserClicked(object sender, EventArgs args)
        {
           // await DisplayAlert("Alert", passUser.Text, "OK");
            await Navigation.PushAsync(new Registrati());


        }
        async void OnLoginUserClicked(object sender, EventArgs args)
        {


             AssegnaEventi();
             AssegnaNews();
             AssegnaUtenti();
            int acces = 0;
            Boolean AccesCons=false;
            for (int a = 0; a < listaUtenti.Count; a++)
            {
                if (emailUser.Text == listaUtenti.ElementAt(a).email && passUser.Text == listaUtenti.ElementAt(a).pass)
                {
                    /*
                       int tipo=1..2..3(indica al back end il tipo di lista chee li richiedi esempio 1 eventi passati,2 eventi in corso  NB se =0 fare come se non ci fosse)
                       String  testoRicerca= null....(testo presente nella ricerca)
                       int ordinamentoFiltri=1...2...3(tipo di orfinamento che si vuole 1.per Data , 2.per ordine alfabetico, 3. raggrupati per azienda NB se =0 fare come se non ci fosse)
                       String Azienda = null(nome dell'azienda in caso di admin che richiede la lista eventi e puo vedere solo i suoi eventi se null restituisci tuute)
                      Constants.listaEventiCorso = await App.EvManager.GetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                       Constants.listaEventiStorico = await App.EvManagerGetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                       Constants.listaEventi = await App.EvManager.GetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                       Constants.listaNews = await App.NManager.GetTasksAsync();
                   Constants.listaEventiAzienda = await App.EvManagerGetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                     * */
                    Constants.CurrentUser = listaUtenti.ElementAt(a);
                    await Navigation.PushAsync(new HomePage());
                    AccesCons = true;
                    break;
                    
                }
                else
                {
                    
                    acces = 1;
                }

            }
            if (acces!=0 && AccesCons==false)
            {
                await DisplayAlert("Attenzione", "E-mail o Password non corretta!", "OK");
            }

        }
        async void OnLoginAdminClicked(object sender, EventArgs args)
        {

            //VerifyUser(emailUser.Text, passUser.Text);
             AssegnaAziende();
             AssegnaEventiAzienda();
             AssegnaNewsAzienda();
            int acces = 0;
            Boolean AccesCons = false;
            for (int a=0;a<listaAziende.Count;a++)
            {
                if (emailAdmin.Text == listaAziende.ElementAt(a).email && passAdmin.Text == listaAziende.ElementAt(a).pass)
                {
                    /*
                      int tipo=1..2..3(indica al back end il tipo di lista chee li richiedi esempio 1 eventi passati,2 eventi in corso  NB se =0 fare come se non ci fosse)
                      String  testoRicerca= null....(testo presente nella ricerca)
                      int ordinamentoFiltri=1...2...3(tipo di orfinamento che si vuole 1.per Data , 2.per ordine alfabetico, 3. raggrupati per azienda NB se =0 fare come se non ci fosse)
                      String Azienda = null(nome dell'azienda in caso di admin che richiede la lista eventi e puo vedere solo i suoi eventi se null restituisci tuute)
                     Constants.listaEventiCorso = await App.EvManager.GetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                      Constants.listaEventiStorico = await App.EvManagerGetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                      Constants.listaEventi = await App.EvManager.GetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                      Constants.listaNews = await App.NManager.GetTasksAsync();
                  Constants.listaEventiAzienda = await App.EvManagerGetTasksAsync(tipo,testoRicerca,ordinamentoFiltri,Azienda);
                    * */
                    Constants.CurrentAdmin = listaAziende.ElementAt(a);
                    await Navigation.PushAsync(new HomePageAdmin());
                    AccesCons = true;
                    break;
                        
                }
                else
                {
                    acces = 1;
                    
                }
            }

           if (acces!= 0 && AccesCons == false)
            {
                await DisplayAlert("Attenzione", "E-mail o Password non corretta!", "OK");
            }
        }

        async void News(object sender, ItemTappedEventArgs e)
        {
            var news = e.Item as ExampleDataNews;
            await Navigation.PushAsync(new PageNews(news.Titolo, news.Descrizione, news.Data, news.Azienda, news.Immagine));

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

        async void AssegnaAziende()
        {
            listaAziende = new List<Admin>();
            // listaAziende = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end
            var ad1 = new Admin("EnerSetting", "Locorotondo", "asd1234rt6f", "setting@enersetting.com", "alternanza");
            var ad2 = new Admin("Barilla", "Modena", "modbar459q7", "admin@barilla.com", "pasta");
            var ad3 = new Admin("ILVA", "Taranto", "dbbsjbkjsdab", "ilva@ilva.com", "ferro");
           
            listaAziende.Add(ad1);
            listaAziende.Add(ad2);
            listaAziende.Add(ad3);
            Constants.listaAziende = listaAziende;
            
        }

        public void AssegnaUtenti()
        {
            listaUtenti = new List<User>();
            Boolean[] inters = new Boolean[7] { true, false, false, true, false, false, false };//carico interessi per usare app senza back end
             AssegnaAziende();
            String[] az = new String[listaAziende.Count];//uso due vettori da riempire con valori back end
            Boolean[] val = new Boolean[listaAziende.Count];// uso due vettori da riempire con valori back end
            val[0] = true;//riempo il vettore con il valore dell'ineteresse di un azienda N.B nel back end sarà fatto con un for unico
            val[1] = false;//riempo il vettore con il valore dell'ineteresse di un azienda
            val[2] = true;//riempo il vettore con il valore dell'ineteresse di un azienda
            for (int x = 0; x < listaAziende.Count; x++)
            {
                az[x] = listaAziende.ElementAt(x).NomeAzienda;
            }
            //listaUtenti=await App.UsManager.GetTasksAsync();// codice da usare per connessione back-end
            var us1 = new User("Filippo", "Corni", "Maschio", "18/09/1998", "italiana", "ingegnere", "Milano", "qwertyuiop", "filippo.corni@gmail.com", "cocco", inters,az,val);
            var us2 = new User("Giuseppe", "Gesualdo", "Maschio", "17/11/1981", "italiana", "falegname", "Betlemme", "gesdrtyuim", "gesu.gesualdo@gmail.com", "asinello", inters,az,val);
            listaUtenti.Add(us1);
            listaUtenti.Add(us2);
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
        public void AssegnaEventiAzienda()
        {
            //codice utilizzato per app senza back end
            listaEvAz = new List<Evento>();
            String im = "https://png.icons8.com/car/ultraviolet/50/3498db";
            
            var ev = new Evento("Medimex", "15/11/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf", false, true, false);
           
            listaEvAz.Add(ev);
            Constants.listaEventiAzienda = listaEvAz;
            Constants.listaEventiIncorsoAzienda = listaEvAz;
            Constants.listEventoAziendaPassato = listaEvAz;
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
        public void AssegnaNewsAzienda()
        {
            //codice utilizzato per app senza back end
            listaNewsAz = new List<News>();

            String im = null;
            var n1 = new News("Evento!!!", "25/05/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var n2 = new News("Secondo evento!!!", "13/06/2019", im, "EnerSetting", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
          
            listaNewsAz.Add(n1);
            listaNewsAz.Add(n2);
            
            Constants.listaNewsAzienda = listaNewsAz;

        }
    }
}
/*
bottone evento in corso
scanner in evento
num di partecipanti attivi e non


    */