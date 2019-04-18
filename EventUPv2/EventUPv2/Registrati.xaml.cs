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
        bool isNewItem;
        public Registrati (bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }
         async void AvantiUser(object sender, EventArgs args)
        {
            
            String n = nome.Text;
            String c = cognome.Text;
            String s = sesso.Text;
            String d = data.Text;
            String naz = nazionalità.Text;
            String tit = titolo.Text;
            String cit = città.Text;
            String codFisc = cf.Text;
            String mail = emailr_user.Text;
            String p = passr_user.Text;
            String cp = cpassr_user.Text;

            if (String.Equals(p, cp))
            {
                Boolean[] inters = new Boolean[6] { false, false, false, false, false, false };
                await AssegnaAziende();
                String[] az = new String[listaAziende.Count];
                Boolean[] val = new Boolean[listaAziende.Count];
                val[0] = false;
                val[1] = false;
                val[2] = false;
                var us= new User(n,c,s,d,naz,tit,cit,codFisc,mail,p,inters,az,val);
                // await App.UsManager.SaveTaskAsync(us, isNewItem);//codice back-end
                Constants.CurrentUser = us;
                await Navigation.PushAsync(new RegistratiInteressi());

                
            }
            else {
                await DisplayAlert("Errore", "le password non corrispondono", "OK");
            }
        }

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
        }

    }
}