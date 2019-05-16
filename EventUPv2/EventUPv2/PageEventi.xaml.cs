using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PageEventi : ContentPage
    {
        public PageEventi(string title,string description, string date , string factory, string image ,int tipo)
        {
            InitializeComponent();
            titolo.Text = title;
            descrizione.Text = description;
            data.Text = date;
            azienda.Text = factory;
            immagine.Source = image;

            switch (tipo) {
                case 1:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = true;
                    partecipa.Text = "Partecipa";
                    break;
                case 2:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = false;
                    partecipa.Text = "Gia Iscritto a Quest'Evento";
                    break;
                case 3:
                    partecipa.IsVisible = true;
                    partecipa.IsEnabled = false;
                    partecipa.Text = "Evento Scaduto";
                    break;
                case 4:
                    partecipa.IsVisible = false;
                    partecipa.IsEnabled = false;
                    partecipa.Text = "";
                    break;

            }



        }

        async void Partecipa_Clicked(object sender, EventArgs e)
        {
            //     await App.ParManager.SaveTaskAsync(Constants.CurrentUser.email+" "+titolo.Text);
            await DisplayAlert("Alert", Constants.CurrentUser.email + " " + titolo.Text, "ok");
        }
    }
}
