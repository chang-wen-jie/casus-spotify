using System;
namespace Spotify
{
	public class Playlist
	{
		public string playlistName = "Mijn afspeellijst";
		public List<(string, double, string, string)> songs = new List<(string, double, string, string)>();
		static Random rnd = new Random();
		int r;
		public double songDuration = 0;


		public void setPlaylistName(string playlistName)
		{
			this.playlistName = playlistName;
		}

		public void addSong(string title, double duration, string artist, string genre)
		{
			(string, double, string, string) song = (title, duration, artist, genre);
			this.songs.Add(song);
		}

		public string getSongs(int index)
		{
			return songs[index].Item1 + ", (" + Math.Round(songs[index].Item2 * 60) + " seconden) van " + songs[index].Item3 + ". Genre: " + songs[index].Item4;
		}

		public void removeSong(int index)
        {
			songs.RemoveAt(index);
            Console.WriteLine("\nNummer is verwijderd.");
        }

		public string playPlaylist(bool shuffle, int index)
        {
			if (shuffle)
            {
				this.r = rnd.Next(songs.Count);
				return songs[r].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(songs[r].Item2 * 60) + " seconden.";
			} else
            {
				return songs[index].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(songs[index].Item2 * 60) + " seconden.";
			}
		}

		public string getSongDuration(bool shuffle, int index)
        {
			if (shuffle)
			{
				songDuration = Math.Round(songs[r].Item2 * 60);
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
			} else
            {
				songDuration = Math.Round(songs[index].Item2 * 60);
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
			}
			return "";
		}
	}
}

