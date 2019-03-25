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
    public partial class Registrati : TabbedPage
    {
        public Registrati ()
        {
            InitializeComponent();
            
        }
         async void RegisterUser(object sender, EventArgs args)
        {
            JsonInterfaceUser JsonIN = new JsonInterfaceUser();
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
                 var us= new User(n,c,s,d,naz,tit,cit,codFisc,mail,p);
               string res= JsonIN.RegisterCode(us);
                await DisplayAlert("Errore", res ,"OK");
            }
            else {
                await DisplayAlert("Errore", "le password non corrispondono", "OK");
            }
        }

    }
}