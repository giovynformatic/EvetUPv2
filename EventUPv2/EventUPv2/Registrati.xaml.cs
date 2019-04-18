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
                var us= new User(n,c,s,d,naz,tit,cit,codFisc,mail,p,inters);
                // await App.UsManager.SaveTaskAsync(us, isNewItem);//codice back-end
                Constants.CurrentUser = us;
                await Navigation.PushModalAsync(new RegistratiInteressi());

                
            }
            else {
                await DisplayAlert("Errore", "le password non corrispondono", "OK");
            }
        }

       
    }
}