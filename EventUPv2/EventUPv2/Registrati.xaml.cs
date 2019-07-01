using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrati : ContentPage
    {
        public List<Admin> listaAziende;
        public List<Evento> listaEv;
        public List<Evento> listaEvIncorso;
        public List<Evento> listaEvPassati;
        bool isNewItem;
        public Registrati (bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
            sesso.SelectedIndex = 0;
            
        }
        async void CompletaUser(object sender, EventArgs args)
        {
            if (condizioni.Checked)
            {
                if (nome.Text != null && cognome.Text != null && emailr_user.Text != null && passr_user != null)
                {
                    String n = nome.Text;
                    String c = cognome.Text;
                    String s = sesso.SelectedItem.ToString();
                    String d = data.Date.ToString().Substring(0, 10);
                    String naz = nazionalità.Text;
                    String tit = titolo.Text;
                    String cit = città.Text;
                    String codFisc = cf.Text;
                    String mail = emailr_user.Text;
                    String p = passr_user.Text;
                    String cp = cpassr_user.Text;

                    if (String.Equals(p, cp))
                    {
                        List<Interessi> a = await App.InManager.GetTasksAsync();
                        String[] inters= new String[1];//{ "Arte", "Musica", "Informatica", "Elettronica", "Architettura" };//carico interessi per usare app senza back end(caricare i dati da back end)
                        Boolean[] valIn = new Boolean[] { false, false, false, false, false };
                        
                        for (int s1 = 0; s1 < a.Count; s1++)
                        {
                            inters[s1] = a.ElementAt(s1).titolo;
                        }
                        AssegnaAziende();
                        String[] az = new String[listaAziende.Count];
                        Boolean[] val = new Boolean[listaAziende.Count];
                        val[0] = false;
                        val[1] = false;
                        val[2] = false;
                        var us = new User(n, c, s, d, naz, tit, cit, codFisc, mail, p, inters, az, val,valIn);

                        Constants.CurrentUser = us;
                      
                       /*
                     int tipo=1..2..3(indica al back end il tipo di lista chee li richiedi esempio 1 eventi passati,2 eventi in corso)
                      Constants.listaEventiCorso = await App.EvManager.GetTasksAsync(1,null,0);
                       Constants.listaEventiStorico = await App.EvManager.GetTasksAsync(2,null,0);
                       Constants.listaEventi = await App.EvManager.GetTasksAsync(3,null,0);*/
                         AssegnaEventi();
                        await Navigation.PushAsync(new RegistratiInteressi());


                    }
                    else
                    {
                        await DisplayAlert("Errore", "le password non corrispondono", "OK");
                    }
                }
                else
                { await DisplayAlert("Attenzione", "I campi nome, cognome, email e password sono obbligatori", "OK"); }
            }
            else
            {
                    await DisplayAlert("Attenzione", "Prima di procedere è necessario accettare i termini e le condizioni d'uso", "OK");

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


    }
}