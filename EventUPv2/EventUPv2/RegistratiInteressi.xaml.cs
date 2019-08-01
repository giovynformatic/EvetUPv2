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

        
        public Interessi interessi;
        public List<SelectableDataInteressi<ExampleDataInteressi>> SelectedData;

        public RegistratiInteressi ()
		{
			InitializeComponent();
           
            interessi = Constants.inter;
            SelectedData = new List<SelectableDataInteressi<ExampleDataInteressi>>();
            for (int a = 0; a < interessi.data.Count(); a++)
            {
                SelectableDataInteressi<ExampleDataInteressi> s;
               SelectedData.Add(s = new SelectableDataInteressi<ExampleDataInteressi>() { Data = new ExampleDataInteressi() {NomeInteressi = interessi.data.ElementAt(a).titolo } });
                s.Selected = Constants.CurrentUser.valIn.ElementAt(a);


            }
          BindingContext = new MultiselectViewModelInteressi(SelectedData);

        }
        async void FinishInteressi(object sender, EventArgs args)
        {
            Admins ads = await App.AdManager.GetTasksAsync();
            
                String[] inters = new String[interessi.data.Length];
                Boolean[] valIn = new Boolean[interessi.data.Length];
                IReadOnlyList<Page> pagine = Navigation.NavigationStack;
            int[] provaId = new int[inters.Length];
            for (int x = 0; x < Constants.listaAziende.data.Length; x++)
            {

                provaId[x] = Constants.listaAziende.data.ElementAt(x).id;
            }
            Constants.CurrentUser.idInteressi = provaId;
            for (int x = 0; x < interessi.data.Length; x++)
                {
                    inters[x] = interessi.data.ElementAt(x).titolo;
                Constants.CurrentUser.idInteressi[x] = 3;//interessi.data.ElementAt(x).id;
                }
                for (int x = 0; x < interessi.data.Length; x++)
                {
                    SelectableDataInteressi<ExampleDataInteressi> s;
                    s = SelectedData.ElementAt(x);
                    valIn[x] = s.Selected;
                }
            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.Registrati")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {
                Constants.CurrentUser.interessi = inters;
                Constants.CurrentUser.valIn = valIn;
                if (ads.success == true)
                {
                    Constants.listaAziende = ads;
                    await Navigation.PushAsync(new SelectAziende());
                    // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());
                }
                else
                {
                    await DisplayAlert("Errore", "errore nella chiamata al server", "OK");
                }
            }
            else
            {
                if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
                {

                   
                    Constants.CurrentUser.interessi = inters;
                    Constants.CurrentUser.valIn = valIn;
                    await Navigation.PopAsync();
                    // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());

                }
            }
            
        }

    
    }
}