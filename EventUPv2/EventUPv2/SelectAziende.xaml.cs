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
          
        public SelectAziende()
        {
            InitializeComponent();
            List<SelectableData<ExampleData>> SelectedData = new List<SelectableData<ExampleData>>();
            List<Admin> listaAziende = new List<Admin>();
            // listaAziende = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end
            var ad1 = new Admin("EnerSetting", "Locorotondo", "asd1234rt6f", "Setting@enersetting.com", "alternanza");
            var ad2 = new Admin("Barilla", "Modena", "modbar459q7", "Admin@barilla.com", "pasta");
            listaAziende.Add(ad1);
            listaAziende.Add(ad2);
            for (int a = 0; a < listaAziende.Count(); a++)
            {
                /* SelectedData = new List<SelectableData<ExampleData>>()
             {
                 new SelectableData<ExampleData>() { Data = new ExampleData() { NomeAzienda = listaAziende.ElementAt(a).NomeAzienda} }

             };*/
                SelectedData.Add(new SelectableData<ExampleData>() { Data = new ExampleData() { NomeAzienda = listaAziende.ElementAt(a).NomeAzienda } });
            }
           
           
            



            BindingContext = new MultiSelectViewModel(SelectedData);
        }

        public ICommand FinishCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopAsync();
                });
            }

        }

       private async Task<List<Admin>> OttieniAziendeAsync()
        {
            List<Admin> Aziende = new List<Admin>();
            Aziende = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end
            return Aziende;
        }
       

    }
}
