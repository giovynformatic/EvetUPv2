using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    public class Evento
    {
        public int id { get; set; }
        public String Titolo { get; set; }
        public String Data { get; set; }
        public String Immagine { get; set; }
        public String Descrizione { get; set; }
        public String Azienda { get; set; }
        public Boolean InCorso { get; set; }
        public Boolean Passato { get; set; }
        public Boolean Futuro { get; set; }
        public Evento(String Titolo,String Data,String Immagine,String Azienda,String Descrizione, Boolean Futuro, Boolean InCorso, Boolean Passato)
        {
            this.Titolo = Titolo;
            this.Data = Data;
            this.Immagine = Immagine;
            this.Azienda = Azienda;
            this.Descrizione = Descrizione;
            this.InCorso = InCorso;
            this.Passato = Passato;
            this.Futuro = Futuro;
        }


    }
}
