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
	public partial class RegistratiInteressi : ContentPage
	{

        List<String> interessi;
        public RegistratiInteressi ()
		{
			InitializeComponent ();
            AssegnaInteressi();

 
        }
        async void FinishInteressi(object sender, EventArgs args)
        {
         //   Boolean[] inters = new Boolean[6] { elettronicaSwitch.On, informaticaSwitch.On, architetturaSwitch.On, arteSwitch.On, musicaSwitch.On, lingueSwitch.On };

            IReadOnlyList<Page> pagine = Navigation.NavigationStack;
            
            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.Registrati")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {
               /// Constants.CurrentUser.interessi = inters;
                await Navigation.PushAsync(new SelectAziende());
               // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());
            }
            else
            {
                if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
                {
                    await Navigation.PopAsync();
                    //await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                 ///   Constants.CurrentUser.interessi = inters;
                   // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());
                    //  await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                }
            }
            /*for (int i = 0; i < pagine.Count; i++)
            {
                EventUPv2.SelectAziende
                String s = pagine.ElementAt(i).ToString();
                Console.WriteLine("pagine.ToString() returns {0}",s);
            }*/
        }

        async void AssegnaInteressi()
        {
            interessi = new List<string>();
            String s = "Arte";
            String s1 = "Musica";
            String s2 = "Informatica";
            String s3 = "Elettronica";
            String s4 = "Architettura";
            interessi.Add(s);
            interessi.Add(s1);
            interessi.Add(s2);
            interessi.Add(s3);
            interessi.Add(s4);

        }
    }
}