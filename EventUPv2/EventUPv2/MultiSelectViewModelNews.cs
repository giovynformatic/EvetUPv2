using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace EventUPv2
{
    public class MultiSelectViewModelNews
    {

        public ObservableCollection<ExampleDataNews> DataListNews { get; set; }
        public List<News> listaN;
        public MultiSelectViewModelNews()
        {
            DataListNews = new ObservableCollection<ExampleDataNews>();
            listaN = Constants.listaNews;
            for (int a = 0; a < listaN.Count(); a++)
            {
                DataListNews.Add(new ExampleDataNews() { Titolo = listaN.ElementAt(a).nome, Descrizione = listaN.ElementAt(a).descrizione, Immagine = listaN.ElementAt(a).immagine, Azienda = listaN.ElementAt(a).Azienda, Data = listaN.ElementAt(a)._Data });
            }
        }

    }

}
