using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EventUPv2
{
    public partial class PopupTaskView 
    {
        public PopupTaskView()
        {
            InitializeComponent();



            NomeP.Text = Constants.CurrentUser.Nome;
            CognomeP.Text = Constants.CurrentUser.Cognome;
            SessoP.Text = Constants.CurrentUser.Sesso;
            DataP.Text = Constants.CurrentUser.Data;
            NazP.Text = Constants.CurrentUser.Nazionalità;
            TitoloP.Text = Constants.CurrentUser.titolo;
            CittaP.Text = Constants.CurrentUser.Città;
            CfP.Text = Constants.CurrentUser.cf;
            EmailP.Text = Constants.CurrentUser.email;

        }
    }
}
