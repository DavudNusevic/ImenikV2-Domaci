using System;
using System.Collections.Generic;

namespace ImenikV2_Domaci
{
    class Program
    {
        //TODO napraviti novi imenik koristeci objekte i recnike :) 
        //Mozete da napravite i drugu verziju u kojoj bi osoba jednostavno sadrzavala objekat
        //klase KontaktInformacije, a u tom objektu bi bile sve potrebe informacije za kontakt

        static Dictionary<string, string> Osobe = new Dictionary<string, string>();
        static void Main(string[] args)
        {
			char odabirKorisnika = ' ';

			while (odabirKorisnika != '5')
			{
				Meni();
				odabirKorisnika = Console.ReadKey().KeyChar;
				Console.Write("\n");

				switch (odabirKorisnika)
				{
					case '1':
						Dodavanje();
						break;
					case '2':
						Ispis();
						break;
					case '3':
						Pretraga();
						break;
					case '4':
						Brisanje();
						break;
					case '5':
						Console.WriteLine("bye :/");
						break;

				}
			}
			Console.ReadKey();
		}

		static void Meni()
		{
			Console.Clear();
			Console.WriteLine("[MENI]\n");

			Console.WriteLine("============================");
			Console.WriteLine("1 - Dodavanje osobe");
			Console.WriteLine("2 - Ispis");
			Console.WriteLine("3 - Pretraga");
			Console.WriteLine("4 - Brisanje");
			Console.WriteLine("5 - Izlazak");
			Console.WriteLine("============================");
			Console.Write("Izaberite :");
		}

		static void Dodavanje()
        {
			Console.Clear();
			Console.WriteLine("[DODAVANJE]\n");

			string ime = null,
				   broj = null;
			do
				unosStringa(ref ime, "Unesite ime nove Osobe :");
			while (Osobe.ContainsKey(ime));

			do
				unosStringa(ref broj, "Unesite novi broj :");
			while (Osobe.ContainsValue(broj));
			Osobe.Add(ime, broj);

			Console.WriteLine("Osoba uspesno dodata");
			Console.Write("\nPritisnite bilo koji taster za povratak na meni ");
			Console.ReadKey();
		}

		static void Ispis()
        {
			Console.Clear();
			Console.WriteLine("[ISPIS]\n");

			foreach (string s in Osobe.Keys)
			{
				Console.WriteLine("===========================================");
				Console.WriteLine($"{s} --- {Osobe[s]}");
				Console.WriteLine("===========================================");
			}

			Console.Write("\nPritisnite bilo koji taster za povratak na meni ");
			Console.ReadKey();
		}

		static void Pretraga()
        {
			Console.Clear();
			Console.WriteLine("[PRETRAGA]\n");

			string zaPretragu = null;
			unosStringa(ref zaPretragu, "Unesite ime osobe ili broj :");
			Console.Write("\n");
			foreach (string s in Osobe.Keys)
			{
				if (s.ToLower().Contains(zaPretragu.ToLower()) || Osobe[s].Contains(zaPretragu))
				{
					Console.WriteLine("===========================================");
					Console.WriteLine($"{s} --- {Osobe[s]}");
					Console.WriteLine("===========================================");
				}
			}

			Console.Write("\nPritisnite bilo koji taster za povratak na meni ");
			Console.ReadKey();
		}

		static void Brisanje()
        {
			Console.Clear();
			Console.WriteLine("[BRISANJE]\n");

			string zaPretragu = null;
			char daLiBrisati;
			unosStringa(ref zaPretragu, "Unesite ime osobe ili broj :");

			Console.Write("\n");
			foreach (string s in Osobe.Keys)
			{
				if (s.ToLower().Contains(zaPretragu.ToLower()) || Osobe[s].Contains(zaPretragu))
				{
					do
					{
						Console.Write($"Da li zelite da izbrisete osobu {s} --- {Osobe[s]} (d/n) :");
						daLiBrisati = Console.ReadKey().KeyChar;
						Console.Write("\n");
					} while (daLiBrisati != 'n' && daLiBrisati != 'd');

					if (daLiBrisati == 'd')
					{
						Osobe.Remove(s);
						Console.WriteLine("Osoba uspesno izbrisana");
						break;
					}

				}
			}

			Console.Write("\nPritisnite bilo koji taster za povratak na meni ");
			Console.ReadKey();
		}

		static void unosStringa(ref string unos, string tekst)
		{
			do
			{
				Console.Write(tekst);
				unos = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(unos));
		}
	}
}
