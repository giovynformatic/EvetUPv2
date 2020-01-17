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
	public partial class RegistratiInteressi : ContentPage
	{

        
        /*public List<Interesse> interessi;
        BackList<Interesse> i;*/
        public List<SelectableDataInteressi<ExampleDataInteressi>> SelectedData;

        public RegistratiInteressi ()
		{
			InitializeComponent();
            /*   System.Threading.Tasks.Task.Factory.StartNew(async () =>
               {
                   i = await ManagerDefine<BackList<Interesse>>.manager.GetTasksAsync(Constants.listInteressiUrl);
                   interessi = i.data;*/
            SelectedData = new List<SelectableDataInteressi<ExampleDataInteressi>>();
                for (int a = 0; a < Constants.interessi.Count(); a++)
                {
                    SelectableDataInteressi<ExampleDataInteressi> s;
                    SelectedData.Add(s = new SelectableDataInteressi<ExampleDataInteressi>() { Data = new ExampleDataInteressi() { NomeInteressi = Constants.interessi.ElementAt(a).titolo } });
                    s.Selected = Constants.CurrentUser.valIn.ElementAt(a);


                }
                BindingContext = new MultiselectViewModelInteressi(SelectedData);
          //  });
            
         

        }
        async void FinishInteressi(object sender, EventArgs args)
        {
            Boolean[] valIn = new Boolean[Constants.interessi.Count];
            int[] idIn = new int[Constants.interessi.Count];
            IReadOnlyList<Page> pagine = Navigation.NavigationStack;
          
           
                for (int x = 0; x < Constants.interessi.Count; x++)
                {
                    SelectableDataInteressi<ExampleDataInteressi> s;
                    s = SelectedData.ElementAt(x);
                    valIn[x] = s.Selected;
                if (valIn[x] == true)
                {
                    idIn[x] = Constants.interessi.ElementAt(x).id;
                }
                }
           

            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.Registrati")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {

                Constants.CurrentUser.valIn = valIn;
                Constants.CurrentUser.interessi = idIn;
                /*    if (i.success == true)
                    {*/

                await Navigation.PushAsync(new SelectAziende());
                    // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());
              /*  }
                else
                {
                    await DisplayAlert("Errore", "errore nella chiamata al server", "OK");
                }*/
            }
            else
            {
                if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
                {

                   
                    Constants.CurrentUser.valIn = valIn;
                    Constants.CurrentUser.interessi = idIn;
                    await Navigation.PopAsync();
                    // Console.WriteLine("pagine.ToString() returns {0}", pagine.ElementAt(pagine.Count - 2).ToString());

                }
            }
            
        }

    
    }
}