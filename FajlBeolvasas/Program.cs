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
