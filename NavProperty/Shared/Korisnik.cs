using System;
using System.Collections.Generic;
using System.Text;

namespace NavProperty.Shared
{
	public class Korisnik
	{
		public int ID { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public List<Adresa> Adrese { get; set; } = new List<Adresa>();
	}

	public class Adresa
	{
		public string ID { get; set; } = Guid.NewGuid().ToString();
		public string Ulica { get; set; }
		public string Broj { get; set; }

		//NP
		public int Korisnik_FK { get; set; }
		public Korisnik Korisnik { get; set; }
	}


}
