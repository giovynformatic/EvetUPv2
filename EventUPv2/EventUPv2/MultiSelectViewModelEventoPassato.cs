using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoPassato
    {

        public ObservableCollection<ExampleDataEvento> DataListEventoPassato { get; set; }
        public List<Evento> listaEv;
        public MultiSelectViewModelEventoPassato()
        {
            DataListEventoPassato = new ObservableCollection<ExampleDataEvento>();
            listaEv = Constants.listaEventiStorico;
            for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoPassato.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }

    }
}
