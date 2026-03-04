namespace Bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
			List<BingoJatekos> jatekosok = new List<BingoJatekos>();

			if (File.Exists("nevek.text"))
			{
				foreach (var fajl in File.ReadAllLines("nevek.text"))
				{
					if (File.Exists(fajl))
					{
						jatekosok.Add(new BingoJatekos(fajl));
					}
				}
			}
			else if (File.Exists("Andi.txt"))
			{
				jatekosok.Add(new BingoJatekos("Andi.txt"));
			}

			Console.WriteLine("4. feladat");
			Console.WriteLine($"A játékosok száma: {jatekosok.Count}");
			Console.WriteLine();

			Console.WriteLine("7. feladat");
			Console.WriteLine("Számhúzás:");

			Random rnd = new Random();
			List<int> huzott = new List<int>();
			bool vanBingo = false;
			int sorszam = 1;

			while (!vanBingo && huzott.Count < 75)
			{
				int szam;
				do
				{
					szam = rnd.Next(1, 76);
				}
				while (huzott.Contains(szam));

				huzott.Add(szam);

				Console.WriteLine($"{sorszam,2}. húzott szám: {szam}");
				sorszam++;

				foreach (var j in jatekosok)
				{
					j.SorsoltSzamotJelol(szam);

					if (j.BingoEll())
					{
						vanBingo = true;
					}
				}
			}
			Console.WriteLine();
		}

	}
}
