using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupInteressi  
    {

        public PopupInteressi(List<SelectableData<ExampleData>> data)
        {
            InitializeComponent();
            BindingContext = new MultiSelectViewModel(data);
        }
    }
}
