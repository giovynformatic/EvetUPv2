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

        public List<String> interessi;
        public List<SelectableDataInteressi<ExampleDataInteressi>> SelectedData;

        public RegistratiInteressi ()
		{
			InitializeComponent();
            AssegnaInteressi();
            SelectedData = new List<SelectableDataInteressi<ExampleDataInteressi>>();
            for (int a = 0; a < interessi.Count(); a++)
            {
                SelectableDataInteressi<ExampleDataInteressi> s;
               SelectedData.Add(s = new SelectableDataInteressi<ExampleDataInteressi>() { Data = new ExampleDataInteressi() {NomeInteressi = interessi.ElementAt(a) } });
                s.Selected = Constants.CurrentUser.valIn.ElementAt(a);


            }
          BindingContext = new MultiselectViewModelInteressi(SelectedData);

        }
        async void FinishInteressi(object sender, EventArgs args)
        {
            String[] inters = new String[interessi.Count];
            Boolean[] valIn = new Boolean[interessi.Count];
            IReadOnlyList<Page> pagine = Navigation.NavigationStack;
            for (int x = 0; x < interessi.Count; x++)
            {
                inters[x] = interessi.ElementAt(x);
            }
            for (int x = 0; x < interessi.Count; x++)
            {
                SelectableDataInteressi<ExampleDataInteressi> s;
                s = SelectedData.ElementAt(x);
                valIn[x] = s.Selected;
            }
            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.Registrati")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {
               Constants.CurrentUser.interessi = inters;
                Constants.CurrentUser.valIn = valIn;
                await Navigation.PushAsync(new SelectAziende());
               // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());
            }
            else
            {
                if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
                {
                  
                    //await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                    Constants.CurrentUser.interessi = inters;
                    Constants.CurrentUser.valIn = valIn;
                    await Navigation.PopAsync();
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
            interessi = new List<String>();
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