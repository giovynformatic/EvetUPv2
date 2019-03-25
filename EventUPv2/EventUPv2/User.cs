using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    class User
    {
        public String Nome;
        public String Cognome;
        public String Sesso;
        public String Data;
        public String Nazionalità;
        public String titolo;
        public String Città;
        public String cf;
        public String email;
        public String pass;
        public User(String Nome, String Cognome, String Sesso, String Data, String Nazionalità, String titolo, String Città, String cf, String email, String pass)
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
        }
    }
}
