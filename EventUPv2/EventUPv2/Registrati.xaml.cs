using EventUPv2.Manager;
using EventUPv2.Models;
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
                   
                    String cit = città.Text;
                    String codFisc = cf.Text;
                    String mail = emailr_user.Text;
                    String p = passr_user.Text;
                    String cp = cpassr_user.Text;
                    String usr = username.Text;
                    
                    if (String.Equals(p, cp))
                    {
                       var us = new User(n, c, s, d, naz,  cit, codFisc, mail, p,usr);
                        Constants.CurrentUser = us;
                        bool[] FalseAziende = new bool[Constants.aziende.Count];
                        bool[] FalseInteressi= new bool[Constants.interessi.Count];
                        for (int z = 0; z < Constants.aziende.Count; z++) { FalseAziende[z] = false; }
                        for (int z = 0; z < Constants.interessi.Count; z++) { FalseInteressi[z] = false; }
                        Constants.CurrentUser.valAz = FalseAziende;
                        Constants.CurrentUser.valIn = FalseInteressi;
                        await Navigation.PushAsync(new RegistratiInteressi());
                    
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