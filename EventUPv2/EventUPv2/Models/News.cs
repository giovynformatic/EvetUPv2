using System;
using System.Collections.Generic;
using System.Text;


namespace EventUPv2
{
    public class News
    {

        public int id { get; set; }
        public String Titolo { get; set; }
        public String Data { get; set; }
        public Byte[] Immagine { get; set; }
        public String Descrizione { get; set; }
        public String Azienda { get; set; }
        public News(String Titolo, String Data, Byte[] Immagine, String Azienda, String Descrizione)
        {
            this.Titolo = Titolo;
            this.Data = Data;
            this.Immagine = Immagine;
            this.Azienda = Azienda;
            this.Descrizione = Descrizione;
        }
    }
}