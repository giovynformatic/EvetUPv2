
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    public partial class FiltriPopupPage
    {

        public FiltriPopupPage()
        {
            InitializeComponent();
            dataf.On = Constants.OrdineFiltri.ElementAt(0);
            nomef.On = Constants.OrdineFiltri.ElementAt(1);
            aziendaf.On = Constants.OrdineFiltri.ElementAt(2);


        }

        async void FinishOrdinamento(object sender, EventArgs args)
        {

            Boolean[] intersf = new Boolean[3] { dataf.On, nomef.On, aziendaf.On };

            await Navigation.PopAsync();
            Constants.CurrentUser.interessi = intersf;

        }
    }
}
