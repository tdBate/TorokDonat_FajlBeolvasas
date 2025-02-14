﻿namespace FajlBeolvasas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];
			Beolvasas("karakterek.txt", karakterek);

			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}
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
