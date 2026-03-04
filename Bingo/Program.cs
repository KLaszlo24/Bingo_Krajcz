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
		}
    }
}
