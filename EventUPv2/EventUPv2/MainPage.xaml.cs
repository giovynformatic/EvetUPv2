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
        public MainPage()
        {
            InitializeComponent();

        }
        async void OnRegisterUserClicked(object sender, EventArgs args)
        {
           // await DisplayAlert("Alert", passUser.Text, "OK");
            await Navigation.PushAsync(new Registrati());


        }
        async void OnLoginUserClicked(object sender, EventArgs args)
        {

            //VerifyUser(emailUser.Text, passUser.Text);
            await AssegnaEventi();
            await AssegnaUtenti();
            int acces = 0;
            Boolean AccesCons=false;
            for (int a = 0; a < listaUtenti.Count; a++)
            {
                if (emailUser.Text == listaUtenti.ElementAt(a).email && passUser.Text == listaUtenti.ElementAt(a).pass)
                {
                    /*
                      * int tipo=1..2..3(indica al back end il tipo di lista chee li richiedi esempio 1 eventi passati,2 eventi in corso)
                      Constants.listaEventiCorso = await App.EvManager.GetTasksAsync(1,null,0);
                       Constants.listaEventiStorico = await App.EvManager.GetTasksAsync(2,null,0);
                       Constants.listaEventi = await App.EvManager.GetTasksAsync(3,null,0);*/
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
            await AssegnaAziende();
            int acces = 0;
            Boolean AccesCons = false;
            for (int a=0;a<listaAziende.Count;a++)
            {
                if (emailAdmin.Text == listaAziende.ElementAt(a).email && passAdmin.Text == listaAziende.ElementAt(a).pass)
                {
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
        /*async void VerifyUser(string a, string b)
        {
            if (a == "User" && b == "user")
            {
                await Navigation.PushModalAsync(new HomePage());
            }
            else if (a == "Admin" && b == "admin") 
            {
                await Navigation.PushModalAsync(new HomePageAdmin());
            }
            else if (!string.IsNullOrEmpty(a) && a != "User" && a != "Admin")
            {
                await DisplayAlert("Alert", "E-mail non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(a))
            {
                await DisplayAlert("Alert", "E-mail non Inserita!", "OK");
            }
            else if (!string.IsNullOrEmpty(b) && b != "user" && a != "admin")
            {
                await DisplayAlert("Alert", "Password non Corretta!", "OK");
            }
            else if (string.IsNullOrEmpty(b))
            {
                await DisplayAlert("Alert", "Password non Inserita!", "OK");
            }
        }*/

        async Task AssegnaAziende()
        {
            listaAziende = new List<Admin>();
            // listaAziende = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end
            var ad1 = new Admin("EnerSetting", "Locorotondo", "asd1234rt6f", "Setting@enersetting.com", "alternanza");
            var ad2 = new Admin("Barilla", "Modena", "modbar459q7", "Admin@barilla.com", "pasta");
            var ad3 = new Admin("ILVA", "Taranto", "dbbsjbkjsdab", "Ilva@ilva.com", "ferro");
           
            listaAziende.Add(ad1);
            listaAziende.Add(ad2);
            listaAziende.Add(ad3);
            Constants.listaAziende = listaAziende;
            
        }

        async Task AssegnaUtenti()
        {
            listaUtenti = new List<User>();
            Boolean[] inters = new Boolean[7] { true, false, false, true, false, false, false };//carico interessi per usare app senza back end
            await AssegnaAziende();
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
            var us1 = new User("Filippo", "Corni", "Maschio", "18/09/1998", "italiana", "ingegnere", "Milano", "qwertyuiop", "Filippo.corni@gmail.com", "cocco", inters,az,val);
            var us2 = new User("Giuseppe", "Gesualdo", "Maschio", "17/11/1981", "italiana", "falegname", "Betlemme", "gesdrtyuim", "Gesu.gesualdo@gmail.com", "asinello", inters,az,val);
            listaUtenti.Add(us1);
            listaUtenti.Add(us2);
        }

        async Task AssegnaEventi()
        {
            //codice utilizzato per app senza back end
            listaEv = new List<Evento>();
            listaEvIncorso = new List<Evento>();
            listaEvPassati = new List<Evento>();
            byte[] im = null;
            var ev1 = new Evento("Corso Cisco","25/05/2019",im,"Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var ev2 = new Evento("Crazyland", "13/06/2019", im, "AWAproductions", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            var ev3 = new Evento("Medimex", "15/11/2019", im, "Puglia Records", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf");
            listaEv.Add(ev1);
            listaEv.Add(ev2);
            listaEv.Add(ev3);
            listaEvIncorso.Add(ev1);
            listaEvIncorso.Add(ev2);
            listaEvIncorso.Add(ev3);
            listaEvPassati.Add(ev1);
            listaEvPassati.Add(ev2);
            listaEvPassati.Add(ev3);
            Constants.listaEventi = listaEv;
            Constants.listaEventiCorso = listaEvIncorso;
            Constants.listaEventiStorico = listaEvPassati;
        }
    }
}
