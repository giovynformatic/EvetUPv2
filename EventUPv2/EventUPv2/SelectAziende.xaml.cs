using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectAziende : ContentPage
    {

        public List<Admin> listaAziende = new List<Admin>();
        public String[] az;
        public List<SelectableData<ExampleData>> SelectedData;
        public SelectAziende()
        {
            InitializeComponent();
             SelectedData = new List<SelectableData<ExampleData>>();
            AssegnaAziende();
            for (int a = 0; a < listaAziende.Count(); a++)
            {
                SelectableData<ExampleData> s;
                SelectedData.Add(s=new SelectableData<ExampleData>() { Data = new ExampleData() { NomeAzienda = listaAziende.ElementAt(a).NomeAzienda }});   
                s.Selected = Constants.CurrentUser.valAz.ElementAt(a);


            }
           BindingContext = new MultiSelectViewModel(SelectedData);


        }
        async void InteressiUser(object sender, EventArgs args)

        {
            az = new String[listaAziende.Count];//uso due vettori da riempire con valori back end
            Boolean[] val = new Boolean[listaAziende.Count];// uso due vettori da riempire con valori back end

            for (int x = 0; x < listaAziende.Count; x++)
            {
                az[x] = listaAziende.ElementAt(x).NomeAzienda;
            }
            for (int x = 0; x < listaAziende.Count; x++)
            {
                SelectableData<ExampleData> s;
                s = SelectedData.ElementAt(x);
                val[x] = s.Selected;
            }


            IReadOnlyList<Page> pagine = Navigation.NavigationStack;

            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.RegistratiInteressi")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {
                Constants.CurrentUser.valAz = val;
                await Navigation.PushAsync(new HomePage());
                //  await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
            }
            else
            {
                if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
                {

                    //await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                    Constants.CurrentUser.valAz = val;
                    Constants.CurrentUser.aziende = az;
                    //  await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                    await Navigation.PopAsync();

                }

            }
        }
        async void AssegnaAziende()
        {
           listaAziende = new List<Admin>();
            // listaAziende = await OttieniAziendeAsync(); da correggere perche il metodo asincrono nel costruttore non si puo chiamare
            var ad1 = new Admin("EnerSetting", "Locorotondo", "asd1234rt6f", "Setting@enersetting.com", "alternanza");
            var ad2 = new Admin("Barilla", "Modena", "modbar459q7", "Admin@barilla.com", "pasta");
            var ad3 = new Admin("ILVA", "Taranto", "dbbsjbkjsdab", "Ilva@ilva.com", "ferro");
            listaAziende.Add(ad1);
            listaAziende.Add(ad2);
            listaAziende.Add(ad3);

            
        }
       

    }
}
