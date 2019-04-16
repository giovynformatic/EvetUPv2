using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
     public  class Admin
    {
        public String NomeAzienda { get; set; }
        public String Sede { get; set; }
        public String piva { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
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
