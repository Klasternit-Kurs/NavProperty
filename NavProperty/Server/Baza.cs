using Microsoft.EntityFrameworkCore;
using NavProperty.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavProperty.Server
{
	public class Baza : DbContext
	{
		public Baza(DbContextOptions<Baza> o) : base(o) { }

		public DbSet<Korisnik> Korisniks { get; set; }
		public DbSet<Adresa> Adresas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Korisnik>().HasKey(k => k.ID);
			modelBuilder.Entity<Adresa>().HasKey(a => a.ID);

			modelBuilder.Entity<Korisnik>().HasMany(k => k.Adrese)
										   .WithOne(a => a.Korisnik)
										   .HasForeignKey(a => a.Korisnik_FK);

			modelBuilder.Entity<Korisnik>().HasData(
				new Korisnik { ID = -1, Ime = "Pera", Prezime = "Peric"},
				new Korisnik { ID = -2, Ime = "Neko", Prezime = "Nekic"},
				new Korisnik { ID = -3, Ime = "Asd", Prezime = "Dsa" },
				new Korisnik { ID = -4, Ime = "Qwe", Prezime = "Ewq" }
				);
			modelBuilder.Entity<Adresa>().HasData(
				new Adresa { ID = "a", Ulica = "abc", Broj = "123", Korisnik_FK=-1 },
				new Adresa { ID = "b", Ulica = "qwe", Broj = "321", Korisnik_FK=-1 },
				new Adresa { ID = "c", Ulica = "zxc", Broj = "765", Korisnik_FK=-2 },
				new Adresa { ID = "d", Ulica = "jftj", Broj = "56756", Korisnik_FK = -3 },
				new Adresa { ID = "e", Ulica = "yukyuk", Broj = "5656yu", Korisnik_FK = -4 }
				);
		}
	}
}
