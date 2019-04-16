using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Interessi : ContentPage
	{
		public Interessi ()
		{
			InitializeComponent ();
         
            var listView = new Xamarin.Forms.ListView();
            ObservableCollection<Admin> aziende = new ObservableCollection<Admin>();

            listView.ItemsSource = aziende;

           
            for (int i = 0; i < 4; i++)
            {
                //  String NomeAzienda = "ffvdfv";//prendere dati dal db
                   // aziende.Add(new Admin() { NomeAzienda });
            }

            this.Content = new StackLayout
            {
                Children =
            {
                
                listView
            }
            };
        }
	}
}