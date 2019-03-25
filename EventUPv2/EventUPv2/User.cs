using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    class User
    {
        private String Nome;
        private String Cognome;
        private String Sesso;
        private String Data;
        private String Nazionalità;
        private String titolo;
        private String Città;
        private String cf;
        private String email;
        private String pass;
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
