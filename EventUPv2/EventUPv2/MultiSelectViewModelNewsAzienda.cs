using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelNewsAzienda
    {
        public ObservableCollection<ExampleDataNews> DataListNewsAzienda { get; set; }
        public List<News> listaEv;
        public MultiSelectViewModelNewsAzienda()
        {
            DataListNewsAzienda = new ObservableCollection<ExampleDataNews>();
            listaEv = Constants.listaNewsAzienda;
            for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListNewsAzienda.Add(new ExampleDataNews() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });
            }
        }
    }
}
