using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageAdmin : TabbedPage
    {
        public HomePageAdmin ()
        {
            InitializeComponent();
            Utype.Text = Constants.CurrentAdmin.NomeAzienda;
        }
        public void datiAzienda(object sender, EventArgs args)
        {


            PopupNavigation.Instance.PushAsync(new PopupTaskViewAzienda());

        }
        public void gestionePasswordAzienda(object sender, EventArgs args)
        {

            PopupNavigation.Instance.PushAsync(new GestionePasswordPopupAzienda());

        }
   
    }
}