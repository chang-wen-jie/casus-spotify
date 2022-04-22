using System;
namespace Spotify
{
	public class Album
	{
		public string Name = "Meek Mill's Mixtape (MMM) Ep.9 Vol.7 ft. Hans Kasan";
		public List<(string, double, string, string)> songs = new List<(string, double, string, string)>();
		public double songDuration = 0;

		public void initializeAlbum()
		{
			(string, double, string, string) song1 = ("Poesje Mauw", 2.01, "Meek Mill", "Gansta rap");
			(string, double, string, string) song2 = ("Ik houd van aardappelen", 7.01, "Meek Mill ft. Eminem", "Hip-hop");
			(string, double, string, string) song3 = ("Chocoladefontein", 3.33, "Meek Mill ft. Die Donkere Man van De Avondshow", "Liefdesliedje");
			this.songs.Add(song1);
			this.songs.Add(song2);
			this.songs.Add(song3);
		}
		public string getSong(int index)
		{
			return this.songs[index].Item1 + " (" + Math.Round(this.songs[index].Item2 * 60) + " seconden), van " + this.songs[index].Item3 + ". Genre: " + this.songs[index].Item4;
		}

		public string playAlbum(int index)
		{
			return this.songs[index].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[index].Item2 * 60) + " seconden.";
		}

		public string getSongDuration(int index)
		{
			songDuration = Math.Round(this.songs[index].Item2 * 60);
			Console.WriteLine("DRUK OP (A) OM TE PAUZEREN\n");
			while (songDuration >= 0)
			{
				Console.Write("\rResterende tijd: {0} ", songDuration);
				songDuration--;
				Thread.Sleep(1000);
				if (Console.KeyAvailable)
				{
					Console.Write("\n\nNummer is gepauzeerd.\na: Afspelen\nb: Stoppen met luisteren\n\nIk wil: ");
					string songAction = Console.ReadLine();
					if (songAction == "a")
					{
						Console.WriteLine();
						continue;
					}
					else
					{
						Console.WriteLine("\n--------------------------------------------------");
						return "";
					}
				}
			}
			Console.WriteLine("- Nummer over!\n\nJe wordt teruggestuurd naar de hoofdmenu...");
			return "";
		}
	}
}

