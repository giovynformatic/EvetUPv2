using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    class Admin
    {
        public String NomeAzienda;
        public String Sede;
        public String piva;
        public String email;
        public String pass;
        public Admin(String NomeAzienda, String Sede, String piva, String email, String pass)
        {
            this.NomeAzienda = NomeAzienda;
            this.Sede = Sede;
            this.piva = piva;
            this.email = email;
            this.pass = pass;
        }

        
    }
}
