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



            NomeP.Text = Constants.CurrentUser.nome;
            CognomeP.Text = Constants.CurrentUser.cognome;
            SessoP.Text = Constants.CurrentUser.sesso;
            DataP.Text = Constants.CurrentUser.datanascita;
            NazP.Text = Constants.CurrentUser.nazionalita;
            TitoloP.Text = Constants.CurrentUser.titolo;
            CittaP.Text = Constants.CurrentUser.citta;
            CfP.Text = Constants.CurrentUser.cf;
            EmailP.Text = Constants.CurrentUser.email;

        }
    }
}
