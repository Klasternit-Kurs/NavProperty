using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using grpcStuff;
using Microsoft.Extensions.Logging;

namespace NavProperty.Server.grpcServisi
{
	public class Korisnici : KorisniciServ.KorisniciServBase
	{
		private readonly Baza _db;
		private readonly ILogger<Korisnici> _log;

		public Korisnici(Baza db, ILogger<Korisnici> log)
		{
			_db = db;
			_log = log;
		}

		public override Task<KorisnikMsg> IzlistajKorisnike(KorisnikMsg request, ServerCallContext context)
		{
			var kor = _db.Korisniks.ToList();
			_db.Adresas.Where(a => a.Korisnik_FK == kor[0].ID).ToList();

			_log.LogInformation(kor[0].Ime);
			_log.LogInformation(kor[0].Adrese[0].Ulica);
			return Task.FromResult(new KorisnikMsg());

		}
	}
}
