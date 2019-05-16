using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PageEventi : ContentPage
    {
        public PageEventi(string item,int tipo)
        {
            InitializeComponent();
            titolo.Text = item;
                

        }

        async void Partecipa_Clicked(object sender, EventArgs e)
        {
            //     await App.ParManager.SaveTaskAsync(Constants.CurrentUser.email+" "+titolo.Text);
            await DisplayAlert("Alert", "testo back end"+ Constants.CurrentUser.email + " " + titolo.Text, "ok");
        }
    }
}
