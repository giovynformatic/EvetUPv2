using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
   public class ExampleDataEvento
    {
        public String Titolo { get; set; }
        public String Data { get; set; }
        public String Immagine { get; set; }
        public String Azienda { get; set; }
        public String Descrizione { get; set; }


        public ExampleDataEvento Clone()
        {
            return new ExampleDataEvento()
            {
                Titolo = Titolo,
                Data = Data,
                Immagine = Immagine,
                Azienda = Azienda,
                Descrizione = Descrizione
            };

        }
    }
}
