using System;
using System.Collections.Generic;
using System.Text;


namespace EventUPv2
{
    public class News
    {

        public int id { get; set; }
        public String nome { get; set; }
        public String _Data { get; set; }
        public String immagine { get; set; }
        public String descrizione { get; set; }
        public String Azienda { get; set; }
       /* public News(String Titolo, String Data, String Immagine, String Azienda, String Descrizione)
        {
            this.nome = Titolo;
            this._Data = Data;
            this.immagine = Immagine;
            this.Azienda = Azienda;
            this.descrizione = Descrizione;
        }*/
    }
}