using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PageEventi : ContentPage
    {
        public PageEventi(String ev)
        {
            InitializeComponent();
            descrizione.Text = ev;
        }
    }
}
