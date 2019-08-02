using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelNewsAzienda
    {
        public ObservableCollection<ExampleDataNews> DataListNewsAzienda { get; set; }
        public List<News> listaNews;
        public MultiSelectViewModelNewsAzienda()
        {
            DataListNewsAzienda = new ObservableCollection<ExampleDataNews>();
            listaNews = Constants.listaNewsAzienda;
            for (int a = 0; a < listaNews.Count; a++)
            {
                DataListNewsAzienda.Add(new ExampleDataNews() { Titolo = listaNews.ElementAt(a).nome, Descrizione = listaNews.ElementAt(a).descrizione, Immagine = listaNews.ElementAt(a).immagine, Azienda = listaNews.ElementAt(a).Azienda, Data = listaNews.ElementAt(a)._Data });
            }
        }
    }
}
