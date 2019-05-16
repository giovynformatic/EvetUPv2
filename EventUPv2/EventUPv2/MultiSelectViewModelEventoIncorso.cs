
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EventUPv2
{
    public class MultiSelectViewModelEventoIncorso
    {
        public ObservableCollection<ExampleDataEvento> DataListEventoIncorso { get; set; }
        public List<Evento> listaEv;
        public MultiSelectViewModelEventoIncorso()
        {
            DataListEventoIncorso = new ObservableCollection<ExampleDataEvento>();
            listaEv = Constants.listaEventiCorso;
            for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoIncorso.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }
    }
}
