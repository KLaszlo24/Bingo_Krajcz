using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
	internal class BingoJatekos
	{
		public string Nev {  get; private set; }
		private int?[,] kartya;
		private bool[,] jelolve;

		public BingoJatekos(string fajlnev)
		{
			Nev = Path.GetFileNameWithoutExtension(fajlnev);

			kartya = new int?[5, 5];
			jelolve = new bool[5, 5];

			string[] sorok = File.ReadAllLines(fajlnev);

			for (int i = 0; i < 5; i++)
			{
				string[] elemek = sorok[i].Split(';');

				for (int j = 0; j < 5; j++)
				{
					if (elemek[j] == "X")
					{
						kartya[i, j] = null;
						jelolve[i, j] = true;
					}
					else
					{
						kartya[i, j] = int.Parse(elemek[j]);
					}
				}
			}
		}

		public void SorsoltSzamotJelol(int szam)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (kartya[i, j] == szam)
					{
						jelolve[i, j] = true;
					}
				}
			}
		}

		public bool BingoEll()
		{
	
			for (int i = 0; i < 5; i++)
			{
				bool teljes = true;
				for (int j = 0; j < 5; j++)
				{
					if (!jelolve[i, j])
						teljes = false;
				}
				if (teljes) return true;
			}

	
			for (int j = 0; j < 5; j++)
			{
				bool teljes = true;
				for (int i = 0; i < 5; i++)
				{
					if (!jelolve[i, j])
						teljes = false;
				}
				if (teljes) return true;
			}

			bool atlo1 = true;
			for (int i = 0; i < 5; i++)
			{
				if (!jelolve[i, i])
					atlo1 = false;
			}
			if (atlo1) return true;


			bool atlo2 = true;
			for (int i = 0; i < 5; i++)
			{
				if (!jelolve[i, 4 - i])
					atlo2 = false;
			}

			return atlo2;
		}
	}
}
