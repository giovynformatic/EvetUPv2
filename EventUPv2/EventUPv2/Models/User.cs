using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
   public  class User
    {
        
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public String Sesso { get; set; }
        public String Data { get; set; }
        public String Nazionalità { get; set; }
        public String titolo { get; set; }
        public String Città { get; set; }
        public String cf { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
        public Boolean[] interessi { get; set; }
        public String[] aziende { get; set; }
        public Boolean[] valAz { get; set; }
        public User(String Nome, String Cognome, String Sesso, String Data, String Nazionalità, String titolo, String Città, String cf, String email, String pass,Boolean[] interessi, String[] aziende,Boolean[] valAz)
        {
            this.Nome = Nome; 
            this.Cognome = Cognome;
            this.Sesso = Sesso;
            this.Data = Data;
            this.Nazionalità = Nazionalità;
            this.titolo = titolo;
            this.Città = Città;
            this.cf = cf;
            this.email = email;
            this.pass = pass;
            this.interessi = interessi;
            this.aziende = aziende;
            this.valAz = valAz;
        }
    }
}
