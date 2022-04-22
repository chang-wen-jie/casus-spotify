using System;
namespace Spotify
{
	public class Song
	{
		public List<(string, double, string, string)> song = new List<(string, double, string, string)>();
		public double songDuration = 0;

		public void initializeSongs()
		{
			(string, double, string, string) song1 = ("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
			(string, double, string, string) song2 = ("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
			(string, double, string, string) song3 = ("Pietje Bel", 4.11, "Gerard Joling", "Liefdesliedje");
			(string, double, string, string) song4 = ("Nederlandse Volkslied", 5.11, "van der Sar", "Volkslied");
			this.song.Add(song1);
			this.song.Add(song2);
			this.song.Add(song3);
			this.song.Add(song4);
		}
		public string getSong(int index)
		{
			return ". " + song[index].Item1 + " (" + Math.Round(song[index].Item2 * 60) + " seconden), van " + song[index].Item3 + ". Genre: " + song[index].Item4;
		}

		public string playSong(int index)
        {
			return song[index].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(song[index].Item2 * 60) + " seconden.";
        }

		public string getSongDuration(int index)
        {
			songDuration = Math.Round(song[index].Item2 * 60);
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
					} else
                    {
                        Console.WriteLine("\n--------------------------------------------------\n\nJe wordt teruggestuurd naar de hoofdmenu...");
						return "";
					}
				}
			}
            Console.WriteLine("- Nummer over!\n\nJe wordt teruggestuurd naar de hoofdmenu...");
			return "";
        }
	}
}

