using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using grpcStuff;
using Microsoft.Extensions.Logging;
using NavProperty.Shared;

namespace NavProperty.Server.grpcServisi
{
	public class Korisnici : KorisniciServ.KorisniciServBase
	{
		private readonly Baza _db;
		private readonly ILogger<Korisnici> _log;
		private readonly Konvertor _kon;

		public Korisnici(Baza db, ILogger<Korisnici> log, Konvertor kon)
		{
			_db = db;
			_log = log;
			_kon = kon;
		}
		//Unary
		public override Task<KorisnikMsg> DajJednogKorisnika(PraznaMsg request, ServerCallContext context)
		{
			var kor = _db.Korisniks.ToList();
			_db.Adresas.Where(a => a.Korisnik_FK == kor[0].ID).ToList();

			_log.LogInformation(kor[0].Ime);
			_log.LogInformation(kor[0].Adrese[0].Ulica);
			return Task.FromResult(_kon.Konvert(kor[0]));
		}

		//Server stream
		public override async Task IzlistajKorisnike(PraznaMsg request, IServerStreamWriter<KorisnikMsg> responseStream, ServerCallContext context)
		{
			var kor = _db.Korisniks.ToList();
			_db.Adresas.ToList();

			foreach (Korisnik k in kor)
			{
				await responseStream.WriteAsync(_kon.Konvert(k));
				await Task.Delay(1000);
			}
		}

		//Client stream
		public override async Task<BrojMsg> Sabirac(IAsyncStreamReader<BrojMsg> requestStream, ServerCallContext context)
		{
			_log.LogDebug("Krecem sa radom");
			int zbir = 0;
			await foreach(BrojMsg br in requestStream.ReadAllAsync())
			{
				_log.LogDebug($"Primio {br.Br}");
				zbir += br.Br;
			}
			_log.LogDebug("Zavrsen stream, vracam rezultat");
			return new BrojMsg { Br = zbir };
		}

		//Duplex stream
		public override async Task DuplexTest(IAsyncStreamReader<BrojMsg> requestStream, IServerStreamWriter<BrojMsg> responseStream, ServerCallContext context)
		{
			await foreach(BrojMsg brm in requestStream.ReadAllAsync())
			{
				await responseStream.WriteAsync(new BrojMsg { Br = brm.Br / 2 });
				await Task.Delay(1000);
				await responseStream.WriteAsync(new BrojMsg { Br = brm.Br * 2 });
			}
		}
	}
}
