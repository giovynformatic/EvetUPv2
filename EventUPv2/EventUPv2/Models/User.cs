using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
   public  class User
    {
        public String nome { get; set; }
        public String username { get; set; }
        public String cognome { get; set; }
        public String sesso { get; set; }
        public String datanascita { get; set; }
        public String nazionalita { get; set; }
        public String titolo { get; set; }
        public String citta { get; set; }
        public String cf { get; set; }
        public String email { get; set; }
        public String password { get; set; }
 
        public int[] interessi { get; set; }
        public int[] aziende { get; set; }
        public bool[] valIn{ get; set; }
        public bool[] valAz{ get; set; }
        public User(String Nome, String Cognome, String Sesso, String Data, String Nazionalità, String Città, String cf, String email, String pass,String Username)
        {
            this.nome = Nome; 
            this.cognome = Cognome;
            this.sesso = Sesso;
            this.datanascita = Data;
            this.nazionalita = Nazionalità;
          
            this.citta = Città;
            this.cf = cf;
            this.email = email;
            this.password = pass;          
            this.username = Username;
        }
    }
}
