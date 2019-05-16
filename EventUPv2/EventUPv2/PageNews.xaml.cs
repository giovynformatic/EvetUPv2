using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PageNews : ContentPage
    {
        public PageNews(string title, string description, string date, string factory, string image)
        {
            InitializeComponent();
            titolo.Text = title;
            descrizione.Text = description;
            data.Text = date;
            azienda.Text = factory;
            immagine.Source = image;
        }

    }
}
