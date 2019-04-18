using System;

namespace EventUPv2
{
	public class ExampleData
	{
        public String NomeAzienda { get; set; }
        public String Sede { get; set; }
        public String piva { get; set; }
        public String email { get; set; }
        public String pass { get; set; }


        public ExampleData Clone()
		{
			return new ExampleData()
			{
                NomeAzienda = NomeAzienda,
                Sede = Sede,
                piva = piva,
                email = email,
                pass = pass
            };
			
		}

	}
}
