﻿using System.ComponentModel.DataAnnotations;

namespace FajlBeolvasas
{
	internal class Program
	{
		static (string,int,int) F02(List<Karakter> karakterek)
		{
			Karakter max = karakterek[0];
			for (int i = 0; i < karakterek.Count; i++)
			{
				if (karakterek[i].Eletero > max.Eletero)
				{
					max = karakterek[i];
				}
			}

			return (max.Nev,max.Eletero,max.Ero);
        }

		static void F03(List<Karakter> karakterek)
		{
			double ossz = 0;

			for (int i = 0; i < karakterek.Count; i++)
			{
				ossz += karakterek[i].Szint;
			}

			Console.WriteLine("Átlag szint: " + ossz / karakterek.Count);
		}

		static void F04(List<Karakter> karakterek)
		{
			for (int a = 0; a < karakterek.Count; a++)
			{
				for (int b = 0; b < karakterek.Count; b++)
				{
					if (karakterek[a].Ero > karakterek[b].Ero)
					{
						Karakter temp = karakterek[a];
						karakterek[a] = karakterek[b];
						karakterek[b] = temp;
					}
				}
			}

			for (int a = 0; a < karakterek.Count; a++)
			{
				Console.WriteLine(karakterek[a]);
            }
		}

		static bool F05(Karakter karakter, int ertek)
		{
			if (karakter.Ero > ertek) { return true; }
			else { return false; }
		}

		static List<Karakter> F06(List<Karakter> karakterek, int szint)
		{
			List<Karakter> szurtKarakter = new List<Karakter>();

			for (int a = 0; a < karakterek.Count; a++)
			{
				if (karakterek[a].Szint > szint)
				{
					szurtKarakter.Add(karakterek[a]);
				}
			}

			return szurtKarakter;
		}

		static void F07_iras(List<Karakter> karakterek)
		{
			string szoveg = "";

			for (int a = 0; a < karakterek.Count; a++)
			{
				szoveg += karakterek[a].Nev + ";"+karakterek[a].Szint+";"+karakterek[a].Eletero+";"+karakterek[a].Ero+"\n";
			}

			File.WriteAllText(Path.Combine("./", "karakterek.csv"), szoveg);
		}

		static void F07_beolvasas(string filenev,List<Karakter> karakterek)
		{
			Beolvasas(filenev, karakterek);
		}

		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];
			Beolvasas("karakterek.txt", karakterek);

			/*foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}*/

			F02(karakterek);
			F03(karakterek);
			F04(karakterek);
			F05(karakterek[2],50);
			F06(karakterek,4);
			F07_iras(karakterek);
			F07_beolvasas("karakterek.csv",karakterek);
		}

		

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			StreamReader sr = new (filenev);
            //Console.WriteLine(sr.ReadToEnd());
            //Console.WriteLine(sr.ReadLine());
			sr.ReadLine();

			while (sr.EndOfStream == false)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
		}
	}
}
