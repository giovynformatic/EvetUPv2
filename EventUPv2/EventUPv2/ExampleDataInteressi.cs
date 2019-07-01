using System;

namespace EventUPv2
{
    public class ExampleDataInteressi
    {
        public String NomeInteressi { get; set; }


        public ExampleDataInteressi Clone()
        {
            return new ExampleDataInteressi()
            {
                NomeInteressi = NomeInteressi
            };

        }

    }
}
