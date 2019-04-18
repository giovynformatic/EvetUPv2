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
       
        public MainPage()
        {
            InitializeComponent();

        }
        async void OnRegisterUserClicked(object sender, EventArgs args)
        {
           // await DisplayAlert("Alert", passUser.Text, "OK");
            await Navigation.PushModalAsync(new Registrati());


        }
        async void OnLoginUserClicked(object sender, EventArgs args)
        {

                //VerifyUser(emailUser.Text, passUser.Text);
                List<User> listaUtenti = new List<User>();
            Boolean[] inters = new Boolean[7] { false, false, false, false, false, false, false};
            //listaUtenti=await App.UsManager.GetTasksAsync();// codice da usare per connessione back-end
            var us1 = new User("Filippo", "Corni", "M", "18/09/1998", "italiana", "ingegnere", "Milano", "qwertyuiop", "Filippo.corni@gmail.com", "cocco",inters);
            var us2 = new User("Giuseppe", "Gesualdo", "M", "17/11/1981", "italiana", "falegname", "Betlemme", "gesdrtyuim", "Gesu.gesualdo@gmail.com", "asinello",inters);
            listaUtenti.Add(us1);
            listaUtenti.Add(us2);
            int acces = 0;
            Boolean AccesCons=false;
            for (int a = 0; a < listaUtenti.Count; a++)
            {
                if (emailUser.Text == listaUtenti.ElementAt(a).email && passUser.Text == listaUtenti.ElementAt(a).pass)
                {
                    Constants.CurrentUser = listaUtenti.ElementAt(a);
                    await Navigation.PushModalAsync(new HomePage());
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
            List<Admin> listaAziende = new List<Admin>();
            // listaAziende = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end
            var ad1 = new Admin("EnerSetting", "Locorotondo","asd1234rt6f","Setting@enersetting.com","alternanza");
            var ad2 = new Admin("Barilla", "Modena", "modbar459q7", "Admin@barilla.com", "pasta");
            listaAziende.Add(ad1);
            listaAziende.Add(ad2);
            int acces = 0;
            Boolean AccesCons = false;
            for (int a=0;a<listaAziende.Count;a++)
            {
                if (emailAdmin.Text == listaAziende.ElementAt(a).email && passAdmin.Text == listaAziende.ElementAt(a).pass)
                {
                    Constants.CurrentAdmin = listaAziende.ElementAt(a);
                    await Navigation.PushModalAsync(new HomePageAdmin());
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
        async void VerifyUser(string a, string b)
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
        }




    }
}
