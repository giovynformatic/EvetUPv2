using System;
namespace EventUPv2
{
  
        public class ExampleDataNews
        {
            public String Titolo { get; set; }
            public String Data { get; set; }
            public String Immagine { get; set; }
            public String Azienda { get; set; }
            public String Descrizione { get; set; }


            public ExampleDataNews Clone()
            {
                return new ExampleDataNews()
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
