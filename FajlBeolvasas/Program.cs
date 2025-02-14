using System.ComponentModel.DataAnnotations;

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

		static void F08(List<Karakter> karakterek)
		{
			for (int a = 0; a < karakterek.Count; a++)
			{
				for (int b = 0; b < karakterek.Count; b++)
				{
					if (karakterek[a].Ero + karakterek[a].Szint > karakterek[b].Ero + karakterek[a].Szint)
					{
						Karakter temp = karakterek[a];
						karakterek[a] = karakterek[b];
						karakterek[b] = temp;
					}
				}
			}

			for (int a = 0; a <3; a++)
			{
				Console.WriteLine(karakterek[a]);
			}
		}

		static void F09(List<Karakter> karakterek)
		{
			for (int a = 0; a < karakterek.Count; a++)
			{
				for (int b = 0; b < karakterek.Count; b++)
				{
					if (karakterek[a].Ero + karakterek[a].Eletero > karakterek[b].Ero + karakterek[b].Eletero)
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

		static void F10(List<Karakter> karakterek)
		{
			Random rnd = new Random();
			Karakter karakter1 = karakterek[rnd.Next(0, karakterek.Count)];
			Karakter karakter2 = karakterek[rnd.Next(0, karakterek.Count)];

			int kor = 0;
			bool marade = true;
			while (marade)
			{
				kor++;
                Console.WriteLine(kor+". kör elkezdődött");
                Console.WriteLine("Adatok:");
                Console.WriteLine("\t"+karakter1);
				Console.WriteLine("\t" + karakter2);

				karakter1.Eletero -= karakter2.Ero;
				karakter2.Eletero -= karakter1.Ero;
				Console.WriteLine("Mindketten egymásra támadtak");

				if (karakter1.Eletero <= 0) { Console.WriteLine(karakter1.Nev+" meghalt. :c"); marade = false; }
				if (karakter2.Eletero <= 0) { Console.WriteLine(karakter2.Nev + " meghalt. :c"); marade = false; }
                Console.WriteLine();
            }
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
            Console.WriteLine();
            F08(karakterek);
            Console.WriteLine();
            F09(karakterek);
			F10(karakterek);
		}

		

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			karakterek.Clear();
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
