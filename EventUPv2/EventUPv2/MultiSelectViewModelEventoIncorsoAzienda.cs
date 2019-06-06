using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoIncorsoAzienda
    {
        public ObservableCollection<ExampleDataEvento> DataListEventoAziendaInCorso { get; set; }
        public List<Evento> listaEv;
         public MultiSelectViewModelEventoIncorsoAzienda()
        {
            DataListEventoAziendaInCorso = new ObservableCollection<ExampleDataEvento>();
             listaEv = Constants.listaEventiIncorsoAzienda;
             for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoAziendaInCorso.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }
    }
}
