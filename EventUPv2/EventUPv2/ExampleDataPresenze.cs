using System;

namespace EventUPv2
{
    public class ExampleDataPresenze
    {
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public String Partecipa { get; set; }



        public ExampleDataPresenze Clone()
        {
            return new ExampleDataPresenze()
            {
                Nome = Nome,
                Cognome = Cognome,
                Partecipa = Partecipa,

            };

        }

    }
}
