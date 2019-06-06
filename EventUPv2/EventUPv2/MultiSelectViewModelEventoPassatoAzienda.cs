using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoPassatoAzienda
    {
        public ObservableCollection<ExampleDataEvento> DataListEventoAziendaPassato { get; set; }
        public List<Evento> listaEv;
         public MultiSelectViewModelEventoPassatoAzienda()
        {
            DataListEventoAziendaPassato = new ObservableCollection<ExampleDataEvento>();
             listaEv = Constants.listEventoAziendaPassato;
             for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoAziendaPassato.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }
    }
}
