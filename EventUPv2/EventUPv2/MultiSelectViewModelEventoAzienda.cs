using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoAzienda
    {
        public ObservableCollection<ExampleDataEvento> DataListEventoAzienda { get; set; }
        public List<Evento> listaEv;
         public MultiSelectViewModelEventoAzienda()
        {
            DataListEventoAzienda = new ObservableCollection<ExampleDataEvento>();
             listaEv = Constants.listaEventiAzienda;
             for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoAzienda.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }
    }
}
