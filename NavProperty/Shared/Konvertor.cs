using grpcStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavProperty.Shared
{
	public class Konvertor
	{
		public AdresaMsg Konvert(Adresa a)
			=> new AdresaMsg { ID = a.ID, Ulica = a.Ulica, Broj = a.Broj };

		public Adresa Konvert(AdresaMsg am)
			=> new Adresa { ID = am.ID, Ulica = am.Ulica, Broj = am.Broj };

		public KorisnikMsg Konvert(Korisnik k)
		{
			KorisnikMsg km = new KorisnikMsg { ID = k.ID, Ime = k.Ime, Prezime = k.Prezime };
			k.Adrese.ForEach(a => km.Adrese.Add(Konvert(a)));
			return km;
		}
		public Korisnik Konvert(KorisnikMsg km)
		{
			Korisnik k = new Korisnik { ID = km.ID, Ime = km.Ime, Prezime = km.Prezime };
			km.Adrese.ToList().ForEach(a => k.Adrese.Add(Konvert(a)));
			return k;
		}
	}
}
