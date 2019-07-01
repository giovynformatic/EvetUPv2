using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EventUPv2 { 
   public class Interessi
{
    public int id { get; set; }
    public String titolo { get; set; }
    public Interessi(int id, String titolo)
    { this.id = id;
        this.titolo = titolo;

    }
}
}