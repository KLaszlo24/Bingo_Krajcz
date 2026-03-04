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
	}
}
