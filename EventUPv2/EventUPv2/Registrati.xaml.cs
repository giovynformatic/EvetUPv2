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
  
        public Admins ads;
        public Interessi a;
        bool isNewItem;
        public Registrati (bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
            Constants.CurrentUser = null;
            sesso.SelectedIndex = 0;
            
        }
        async void CompletaUser(object sender, EventArgs args)
        {
            if (condizioni.Checked)
            {
                if (nome.Text != null && cognome.Text != null && emailr_user.Text != null && passr_user != null && username.Text!=null && nazionalità.Text!=null&& città.Text!=null && cf.Text!=null)
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
                    String usr = username.Text;
                    
                    if (String.Equals(p, cp))
                    {

                         a = await App.InManager.GetTasksAsync();
                        ads = await App.AdManager.GetTasksAsync();

                        if (a.success == true )
                        {
                            
                            String[] inters = new String[a.data.Length];//{ "Arte", "Musica", "Informatica", "Elettronica", "Architettura" };//carico interessi per usare app senza back end(caricare i dati da back end)
                            Boolean[] valIn = new Boolean[a.data.Length];

                        
                       
                            String[] az = new String[ads.data.Length];
                            Boolean[] val = new Boolean[ads.data.Length];
                           
                            var us = new User(n, c, s, d, naz, tit, cit, codFisc, mail, p, inters, az, val, valIn,usr);

                            Constants.CurrentUser = us;

                            /*
                          int tipo=1..2..3(indica al back end il tipo di lista chee li richiedi esempio 1 eventi passati,2 eventi in corso)
                           Constants.listaEventiCorso = await App.EvManager.GetTasksAsync(1,null,0);
                            Constants.listaEventiStorico = await App.EvManager.GetTasksAsync(2,null,0);
                            Constants.listaEventi = await App.EvManager.GetTasksAsync(3,null,0);*/
                           
                            Constants.inter = a;
                            Constants.listaAziende = ads;
                            await Navigation.PushAsync(new RegistratiInteressi());
                        }
                        else
                        {
                            await DisplayAlert("Errore", "errore nella chiamata al server", "OK");
                        }

                    }
                    else
                    {
                        await DisplayAlert("Errore", "le password non corrispondono", "OK");
                    }
                }
                else
                { await DisplayAlert("Attenzione", "I campi nome, cognome, nazionalità, cf, città, email, username e password sono obbligatori", "OK"); }
            }
            else
            {
                    await DisplayAlert("Attenzione", "Prima di procedere è necessario accettare i termini e le condizioni d'uso", "OK");

            }
                
            
        }

     



    }
}