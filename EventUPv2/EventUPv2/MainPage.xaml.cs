using EventUPv2.Manager;
using EventUPv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;
using System.Diagnostics;


namespace EventUPv2
{
    public partial class MainPage : TabbedPage

    {
       public BackList<Interesse> i;
        BackList<Admin> ads;
        public List<User> listaUtenti;
        public List<Evento> listaEv;
        public List<Evento> listaEvIncorso;
        public List<Evento> listaEvPassati;
        public List<News> listaVisualizzataNews;
        public List<News> listaNewsAz;
        public List<Evento> listaEvAz;
        public Login login;
        public Back<User> user;
        IDevice device = DependencyService.Get<IDevice>();
        String Uid = "";
        public MainPage()
        {
            Constants.AccesCons = false;

            if (device != null)
            {
                Uid = device.Id;
            }
            InitializeComponent();
            
        }
        async void OnRegisterUserClicked(object sender, EventArgs args)
        {
            
            i = await ManagerDefine<BackList<Interesse>>.manager.GetTasksAsync(Constants.listInteressiUrl);
            ads = await ManagerDefine<BackList<Admin>>.manager.GetTasksAsync(Constants.listAdminUrl);
            Constants.interessi = i.data;
            Constants.aziende = ads.data;
            Constants.CurrentUser = null;
            await Navigation.PushAsync(new Registrati());


        }
        public async Task<Login> getloginasync()
        {
            Task<Login> requestTask = ManagerDefine<Login, Login_Send, Login_Send>.manager.GetTasksAsyncnotoken(Constants.LoginUrl, new Login_Send(emailUser.Text, passUser.Text, Uid));
            var timeoutTask = Task.Delay(50);
            var completedTask = await Task.WhenAny(requestTask, timeoutTask);
            if (completedTask == timeoutTask) { await DisplayAlert("Errore", "Timeout nella chiamata al server", "ok"); throw new OperationCanceledException(); }
            return await requestTask;
        }
        async void OnLoginUserClicked(object sender, EventArgs args)
        {


            Constants.AccesCons = false;
            if (emailUser.Text != null || passUser.Text != null)
            {


                login = await getloginasync();
                if (login != null)
                {
                    Constants.token = login.token;

                    Constants.AccesCons = true;
                    Device.StartTimer(TimeSpan.FromMilliseconds(10000), () =>
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(async () =>
                        {
                            // da usare con il back-end completo user = await ManagerDefine<Back<User>>.manager.GetTasksAsync(Constants.UserUrl);
                            if (user != null)
                            {
                                Constants.CurrentUser = user.data;
                            }
                            else
                            {
                                Debug.WriteLine("user non caricato");
                            }
                        });
                        return false;
                    });


                }

                else
                {
                    await DisplayAlert("Attenzione", "E-mail o Password non corretta!", "OK");
                }

            }
        }
        async void OnLoginAdminClicked(object sender, EventArgs args)
        {
               /*login admin da scommentare dopo user
            //VerifyUser(emailUser.Text, passUser.Text);
          // AssegnaAziende();
             AssegnaEventiAzienda();
           //AssegnaNewsAzienda();
            int acces = 0;
            Boolean AccesCons = false;
            for (int a=0;a<.Count;a++)
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
            } */
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

     
    }
}
