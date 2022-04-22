using System;
namespace Spotify
{
	public class Person : Playlist
	{
		public string name = "Spotify Gebruiker";
		public List<string> friends = new List<string>();
		public List<string> users = new List<string>();
		List<(string, double, string, string)> jaapSongs = new List<(string, double, string, string)>();
		List<(string, double, string, string)> jasperSongs = new List<(string, double, string, string)>();
		List<(string, double, string, string)> gerritSongs = new List<(string, double, string, string)>();
		List<(string, double, string, string)> marijnSongs = new List<(string, double, string, string)>();
		List<(string, double, string, string)> johnnySongs = new List<(string, double, string, string)>();
		public double songDuration = 0;

		public void initializePersons()
		{
			(string, double, string, string) song1 = ("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
			(string, double, string, string) song2 = ("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
			(string, double, string, string) song3 = ("Pietje Bel", 4.11, "Gerard Joling", "Liefdesliedje");
			(string, double, string, string) song4 = ("Nederlandse Volkslied", 5.11, "van der Sar", "Volkslied");
			
			Person jaap = new Person();
			jaap.setName("Jaap Janssen");
			this.users.Add(jaap.name);
			this.jaapSongs.Add(song2);
			this.jaapSongs.Add(song1);
			
			Person jasper = new Person();
			jasper.setName("Jasper Klaassen");
			this.users.Add(jasper.name);
			this.jasperSongs.Add(song1);

			Person gerrit = new Person();
			gerrit.setName("Gerrit Gerritsen");
			this.users.Add(gerrit.name);
			this.gerritSongs.Add(song4);

			Person marijn = new Person();
			marijn.setName("Marijn Langen");
			this.users.Add(marijn.name);
			this.marijnSongs.Add(song3);
			this.marijnSongs.Add(song4);
			this.marijnSongs.Add(song1);

			Person johnny = new Person();
			johnny.setName("Johnny Karel");
			this.users.Add(johnny.name);
			this.johnnySongs.Add(song2);
		}

		public void setName(string name)
		{
			this.name = name;
		}

		public void addFriend(string friend)
        {
			this.friends.Add(friend);
        }

		public string getFriends(int index)
		{
			return friends[index];
		}
		
		public string getUsers(int index)
		{
			return users[index];
		}

		public string getUserInfo(int index)
        {
			string afspeellijst = "";
			switch (index)
            {
				default:
					afspeellijst = "JaapBeats";
					break;
				case 1:
					afspeellijst = "Klaasen Klassiks";
					break;
				case 2:
					afspeellijst = "GorillaMode";
					break;
				case 3:
					afspeellijst = "Marijn's afspeellijst";
					break;
				case 4:
					afspeellijst = "Karel's Parel";
					break;
			}
			return users[index] + "\n\nAfspeellijst: " + afspeellijst;
		}

		public string getUserPlaylist(int index)
		{
			switch (index)
			{
				default:
					for (int i = 0; i < this.jaapSongs.Count; i++)
						Console.WriteLine(i + ". " + this.jaapSongs[i]);
					break;
				case 1:
					for (int i = 0; i < this.jasperSongs.Count; i++)
						Console.WriteLine(i + ". " + this.jasperSongs[i]);
					break;
				case 2:
					for (int i = 0; i < this.gerritSongs.Count; i++)
						Console.WriteLine(i + ". " + this.gerritSongs[i]);
					break;
				case 3:
					for (int i = 0; i < this.marijnSongs.Count; i++)
						Console.WriteLine(i + ". " + this.johnnySongs[i]);
					break;
				case 4:
					for (int i = 0; i < this.johnnySongs.Count; i++)
						Console.WriteLine(i + ". " + this.johnnySongs[i]);
					break;
			}
			return "";
		}

		public string playUserPlaylist(int index)
		{
			List<(string, double, string, string)> songs = new List<(string, double, string, string)>();
			(string, double, string, string) song1 = ("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
			(string, double, string, string) song2 = ("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
			(string, double, string, string) song3 = ("Pietje Bel", 4.11, "Gerard Joling", "Liefdesliedje");
			(string, double, string, string) song4 = ("Nederlandse Volkslied", 5.11, "van der Sar", "Volkslied");
			switch (index)
			{
				default:
					this.songs.Add(song2);
					this.songs.Add(song1);
					for (int i = 0; i < this.songs.Count; i++)
					{
                        Console.WriteLine(this.songs[i].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[i].Item2 * 60) + " seconden.");
						songDuration = Math.Round(this.songs[i].Item2 * 60);
						Console.WriteLine("\nDRUK OP (A) OM TE PAUZEREN\n");
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
					break;
				case 1:
					this.songs.Add(song1);
					for (int i = 0; i < this.songs.Count; i++)
					{
						Console.WriteLine(this.songs[i].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[i].Item2 * 60) + " seconden.");
						songDuration = Math.Round(this.songs[i].Item2 * 60);
						Console.WriteLine("\nDRUK OP (A) OM TE PAUZEREN\n");
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
									return "\n--------------------------------------------------";
								}
							}
						}
					}
					break;
				case 2:
					this.songs.Add(song4);
					for (int i = 0; i < this.songs.Count; i++)
					{
						Console.WriteLine(this.songs[i].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[i].Item2 * 60) + " seconden.");
						songDuration = Math.Round(this.songs[i].Item2 * 60);
						Console.WriteLine("\nDRUK OP (A) OM TE PAUZEREN\n");
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
									return "\n--------------------------------------------------";
								}
							}
						}
					}
					break;
				case 3:
					this.songs.Add(song3);
					this.songs.Add(song4);
					this.songs.Add(song1);
					for (int i = 0; i < this.songs.Count; i++)
					{
						Console.WriteLine(this.songs[i].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[i].Item2 * 60) + " seconden.");
						songDuration = Math.Round(this.songs[i].Item2 * 60);
						Console.WriteLine("\nDRUK OP (A) OM TE PAUZEREN\n");
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
					break;
				case 4:
					this.songs.Add(song2);
					for (int i = 0; i < this.songs.Count; i++)
					{
						Console.WriteLine(this.songs[i].Item1 + " wordt nu afgespeeld.\nDuratie: " + Math.Round(this.songs[i].Item2 * 60) + " seconden.");
						songDuration = Math.Round(this.songs[i].Item2 * 60);
						Console.WriteLine("\nDRUK OP (A) OM TE PAUZEREN\n");
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
					break;
			}
			return "";
		}
	}
}
