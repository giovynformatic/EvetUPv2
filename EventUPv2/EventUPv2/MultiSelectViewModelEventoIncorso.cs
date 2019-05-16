
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
        // public List<SelectableDataEvento<ExampleDataEvento>> SelectedDataEventi;

        public MultiSelectViewModelEventoIncorso()
        {
            DataListEventoIncorso = new ObservableCollection<ExampleDataEvento>();

            // DataListEvento.Add(new Evento( "Corso Cisco", "25/05/2019", null, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf") );


            listaEv = Constants.listaEventiCorso;
            // SelectedDataEventi = new List<SelectableDataEvento<ExampleDataEvento>>();


            for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEventoIncorso.Add(new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo, Descrizione = listaEv.ElementAt(a).Descrizione, Immagine = listaEv.ElementAt(a).Immagine, Azienda = listaEv.ElementAt(a).Azienda, Data = listaEv.ElementAt(a).Data });


            }
        }
    }
}
