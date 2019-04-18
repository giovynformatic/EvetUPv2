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
	public partial class RegistratiInteressi : ContentPage
	{
		public RegistratiInteressi ()
		{
			InitializeComponent ();
            elettronicaSwitch.On = Constants.CurrentUser.interessi.ElementAt(0);
            informaticaSwitch.On = Constants.CurrentUser.interessi.ElementAt(1);
            architetturaSwitch.On = Constants.CurrentUser.interessi.ElementAt(2);
            arteSwitch.On = Constants.CurrentUser.interessi.ElementAt(3);
            musicaSwitch.On = Constants.CurrentUser.interessi.ElementAt(4);
            lingueSwitch.On = Constants.CurrentUser.interessi.ElementAt(5);

        }
        async void AvantiUser2(object sender, EventArgs args)
        {
            Boolean[] inters = new Boolean[6] { elettronicaSwitch.On, informaticaSwitch.On, architetturaSwitch.On, arteSwitch.On, musicaSwitch.On, lingueSwitch.On };
            Constants.CurrentUser.interessi = inters;
          //  Console.WriteLine("inters[2].ToString() returns {0}", inters[2]);
            
        }
    }
}