using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Web;
using EventUPv2.Manager;
using EventUPv2.Models;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectAziende : ContentPage
    {

     /*   public List<Admin> aziende;
        BackList<Admin> ads;*/
        public List<SelectableData<ExampleData>> SelectedData;
        
        public SelectAziende()
        {
            InitializeComponent();
            
           /* System.Threading.Tasks.Task.Factory.StartNew(async () =>
            {
                ads = await ManagerDefine<BackList<Admin>>.manager.GetTasksAsync(Constants.listAdminUrl);
                aziende = ads.data;*/
                SelectedData = new List<SelectableData<ExampleData>>();
                for (int a = 0; a < Constants.aziende.Count; a++)
                {
                    SelectableData<ExampleData> s;
                    SelectedData.Add(s = new SelectableData<ExampleData>() { Data = new ExampleData() { NomeAzienda = Constants.aziende.ElementAt(a).nome } });
                    s.Selected = Constants.CurrentUser.valAz.ElementAt(a);


                }
                BindingContext = new MultiSelectViewModel(SelectedData);


          //  });
          
        }
        async void AziendeUser(object sender, EventArgs args)

        {
           
               
                Boolean[] valAz = new Boolean[Constants.aziende.Count];
                int[] idAz = new int[Constants.aziende.Count];
                 
            for (int x = 0; x < Constants.aziende.Count; x++)
            {
                SelectableData<ExampleData> s;
                s = SelectedData.ElementAt(x);
                valAz[x] = s.Selected;
                if (valAz[x])
                {
                    idAz[x] = Constants.aziende.ElementAt(x).id;
                }
            }


            IReadOnlyList<Page> pagine = Navigation.NavigationStack;

            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.RegistratiInteressi")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {

                Constants.CurrentUser.valAz = valAz;
                Constants.CurrentUser.interessi = idAz;
                var response = await ManagerDefine<User>.manager.ModifyTodoItemAsyncnotoken(Constants.CurrentUser, Constants.registerUrl);//codice da usare per connesione backend
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Attendere", "Attendere conferma registrazione tramite mail", "OK");
                }
                else {
                   
                    await DisplayAlert("Errore", response.ReasonPhrase, "OK");
                    await Navigation.PushAsync(new MainPage());
              

                }

            }
                else
                {
                    if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente

                    {

                        //await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                    //    Constants.CurrentUser.valAz = val;
                   //     Constants.CurrentUser.aziende = az;
                        //  await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                        await Navigation.PopAsync();

                    }

                }
            }
            
   
       

    }
}
