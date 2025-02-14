using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajlBeolvasas
{
	internal class Karakter
	{
		private string nev;
		private int szint;
		private int eletero;
		private int ero;

		public Karakter(string nev, int szint, int eletero, int ero)
		{
			this.nev = nev;
			this.szint = szint;
			this.eletero = eletero;
			this.ero = ero;
		}

		public string Nev { get => nev; set => nev = value; }
		public int Szint { get => szint; set => szint = value; }
		public int Eletero { get => eletero; set => eletero = value; }
		public int Ero { get => ero; set => ero = value; }

		public override string ToString()
		{
			return $"Név: {this.nev}, Szint: {this.szint}, Életerő: {this.eletero}, Erő: {this.ero}";
		}
	}
}
