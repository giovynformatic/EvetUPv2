using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EventUPv2
{
    public class MultiSelectViewModelEvento
    {
      public ObservableCollection<ExampleDataEvento> DataListEvento { get; set; }
        public List<Evento> listaEv;
        public MultiSelectViewModelEvento() {
              DataListEvento = new ObservableCollection<ExampleDataEvento>();
              listaEv = Constants.listaEventi; 
           for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEvento.Add( new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda=listaEv.ElementAt(a).Azienda, Data=listaEv.ElementAt(a).Data } );
            }
        }

      
    }


}
