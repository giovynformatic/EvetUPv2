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
            List<SelectableData<ExampleData>> SelectedData = new List<SelectableData<ExampleData>>()
            {
                new SelectableData<ExampleData>() { Data = new ExampleData() { Name = "Test1", Description = "Description1" } },
                new SelectableData<ExampleData>() { Data = new ExampleData() { Name = "Test2", Description = "Description2" } },
                new SelectableData<ExampleData>() { Data = new ExampleData() { Name = "Test3", Description = "Description3" } },
                new SelectableData<ExampleData>() { Data = new ExampleData() { Name = "Test4", Description = "Description4" } },
                new SelectableData<ExampleData>() { Data = new ExampleData() { Name = "Test5", Description = "Description5" } }
            };


            InitializeComponent();
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
    }
}
