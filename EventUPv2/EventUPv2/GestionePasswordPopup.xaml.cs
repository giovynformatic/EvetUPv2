using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class GestionePasswordPopup 
    {
        public GestionePasswordPopup()
        {
            InitializeComponent();
        }

        async void ModifyButton(object sender, EventArgs args)
        {
            await DisplayAlert("Alert", "Modificato", "OK");
        }
    }
}
