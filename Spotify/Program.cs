using Spotify;
class Program
{
    static void Main(String[] args)
    {
        //INTRODUCTIE
        Console.Write("Welkom, leuk dat je voor Spotify hebt gekozen!\nHoe kunnen wij jou noemen?: ");
        Person person = new Person();
        person.initializePersons();
        string username = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(username))
        {
            person.setName(username);
        }

        Console.Write("\nHoi " + person.name + "!\nLaten wij beginnen, hoe heet jouw afspeellijst?: ");
        Playlist playlist = new Playlist();
        string playlistName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(playlistName))
        {
            playlist.setPlaylistName(playlistName);
        }
        
        Console.WriteLine("\n" + playlist.playlistName + " is aangemaakt.\n");
        Task.Delay(1000).Wait();
        Console.WriteLine("--------------------------------------------------\n" + @"
████████████████████████████████████████
█─▄▄▄▄█▄─▄▄─█─▄▄─█─▄─▄─█▄─▄█▄─▄▄─█▄─█─▄█
█▄▄▄▄─██─▄▄▄█─██─███─████─███─▄████▄─▄██
▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▄▀▄▄▄▀▀▀▀▄▄▄▀▀
" + "\n--------------------------------------------------");
        Console.WriteLine("\nHoi " + person.name + "! Wat wil je doen?");

        // BEGIN HOOFDMENU
        while (true)
        {
            string userAction = "";
            Console.Write("\na: Naar mijn afspeellijst\nb: Beschikbare nummers bekijken\nc: Gebruikers bekijken\nd: Mijn vriendenlijst ophalen\ne: Spotify afsluiten\n\nIk wil: ");
            string userActionChoice = Console.ReadLine().ToLower();
            List<string> userActionOptions = new List<string>(new string[] { "a", "b", "c", "d", "e" });
            int userActionExists = userActionOptions.IndexOf(userActionChoice);
            if (userActionExists == -1)
            {
                Console.WriteLine("\n--------------------------------------------------\n\nSorry, ik heb dat niet begrepen, laten we het even opnieuw proberen.\n\n--------------------------------------------------");
            }
            else
            {
                switch (userActionChoice)
                {

                    // PROGRAMMA AFSLUITEN
                    default:
                        Console.WriteLine("\n--------------------------------------------------\nTot ziens!\n--------------------------------------------------");
                        return;

                    // AFSPEELLIJST ACTIES
                    case "a":
                        Console.WriteLine("\n--------------------------------------------------\n\n" + playlist.playlistName + " (" + playlist.songs.Count + " nummers):\n");

                        if (playlist.songs.Count == 0)
                        {
                            Console.WriteLine("Het is nogal leeg hier, je wordt teruggestuurd naar de hoofdmenu...\n\n--------------------------------------------------");
                        } else
                        {
                            for (int i = 0; i < playlist.songs.Count; i++)
                                Console.WriteLine(i + ". " + playlist.getSongs(i));
                            Console.Write("\na: Afspeellijst afspelen\nb: Nummer verwijderen\nc: Terug naar hoofdmenu\n\nIk wil: ");
                            string playlistAction = Console.ReadLine().ToLower();

                            if (playlistAction == "a")
                            {
                                Console.Write("Op willekeurige volgorde afspelen? (j/n): ");
                                string shufflePlay = Console.ReadLine().ToLower();
                                Console.WriteLine();

                                if (shufflePlay == "j")
                                {
                                    for (int i = 0; i < playlist.songs.Count; i++)
                                    {
                                        Console.WriteLine(playlist.playPlaylist(true, i) + "\n");
                                        Console.WriteLine(playlist.getSongDuration(true, i));
                                    }
                                    Console.WriteLine("Afspeellijst doorgelopen.\n\n--------------------------------------------------");
                                } else
                                {
                                    for (int i = 0; i < playlist.songs.Count; i++)
                                    {

                                        Console.WriteLine(playlist.playPlaylist(false, i) + "\n");
                                        Console.WriteLine(playlist.getSongDuration(false, i));
                                    }
                                    Console.WriteLine("Afspeellijst doorgelopen.\n\n--------------------------------------------------");
                                }
                            } else if (playlistAction == "b")
                            {
                                Console.Write("Verwijder nummer: ");
                                string removeSong = Console.ReadLine();
                                bool isParsable = int.TryParse(removeSong, out int n);

                                if (isParsable)
                                {
                                    List<int> availableSongs = new List<int>();
                                    for (int i = 0; i < playlist.songs.Count; i++)
                                        availableSongs.Add(i);
                                    if (availableSongs.Contains(Int32.Parse(removeSong)))
                                    {
                                        playlist.removeSong(Int32.Parse(removeSong));
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n\n--------------------------------------------------"); ;
                                    }
                                } else
                                {
                                    Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n\n--------------------------------------------------");
                                }
                            }
                        }
                        break;

                    // NUMMERS ACTIES
                    case "b":
                        Console.WriteLine("\n--------------------------------------------------\n\nBeschikbare nummers:\n");
                        Song song = new Song();
                        song.initializeSongs();
                        Album album = new Album();
                        album.initializeAlbum();
                        
                        for (int i = 0; i < song.song.Count; i++)
                            Console.WriteLine(i + song.getSong(i));
                        
                        Console.WriteLine("\nNieuwste album: " + album.Name);
                        Console.Write("\na: Nummer bekijken\nb: Album bekijken\nc: Terug naar hoofdmenu\n\nIk wil: ");
                        userAction = Console.ReadLine().ToLower();

                        if (userAction == "a")
                        {
                            Console.Write("Bekijk nummer: ");
                            string songSelection = Console.ReadLine();
                            string songAction = "";
                            Console.WriteLine("\n--------------------------------------------------");
                            switch (songSelection)
                            {
                                default:
                                    Console.WriteLine("\nInvalide keuze\n");
                                    break;
                                case "0":
                                    Console.WriteLine("\n" + song.getSong(0));
                                    Console.Write("\na: Nummer afspelen\nb: Toevoegen aan " + playlist.playlistName + "\n\nIk wil: ");
                                    songAction = Console.ReadLine().ToLower();
                                    if (songAction == "a")
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n");
                                        Console.WriteLine(song.playSong(0) + "\n");
                                        Console.WriteLine(song.getSongDuration(0));
                                    } else if (songAction == "b")
                                    {
                                        playlist.addSong("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
                                        Console.WriteLine("\nNummer toegevoegd\n");
                                    } else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n");
                                    }
                                    break;
                                case "1":
                                    Console.WriteLine("\n" + song.getSong(1));
                                    Console.Write("\na: Nummer afspelen\nb: Toevoegen aan " + playlist.playlistName + "\n\nIk wil: ");
                                    songAction = Console.ReadLine().ToLower();
                                    if (songAction == "a")
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n");
                                        Console.WriteLine(song.playSong(1) + "\n");
                                        Console.WriteLine(song.getSongDuration(1));
                                    } else if (songAction == "b")
                                    {
                                        playlist.addSong("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
                                        Console.WriteLine("\nNummer toegevoegd\n");
                                    } else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("\n" + song.getSong(2));
                                    Console.Write("\na: Nummer afspelen\nb: Toevoegen aan " + playlist.playlistName + "\n\nIk wil: ");
                                    songAction = Console.ReadLine().ToLower();
                                    if (songAction == "a")
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n");
                                        Console.WriteLine(song.playSong(2) + "\n");
                                        Console.WriteLine(song.getSongDuration(2));
                                    } else if (songAction == "b")
                                    {
                                        playlist.addSong("Pietje Bel", 4.11, "Gerard Joling", "Liefdesliedje");
                                        Console.WriteLine("\nNummer toegevoegd\n");
                                    } else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("\n" + song.getSong(3));
                                    Console.Write("\na: Nummer afspelen\nb: Toevoegen aan " + playlist.playlistName + "\n\nIk wil: ");
                                    songAction = Console.ReadLine().ToLower();
                                    if (songAction == "a")
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n");
                                        Console.WriteLine(song.playSong(3) + "\n");
                                        Console.WriteLine(song.getSongDuration(3));
                                    } else if (songAction == "b")
                                    {
                                        playlist.addSong("Nederlandse Volkslied", 5.11, "Edwin van der Sar", "Volkslied");
                                        Console.WriteLine("\nNummer toegevoegd\n");
                                    } else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n");
                                    }
                                    break;
                            }
                            Console.WriteLine("--------------------------------------------------");
                        } else if (userAction == "b")
                        {
                            Console.WriteLine("\n--------------------------------------------------\n\nNummers (" + album.songs.Count + "):\n");

                            for (int i = 0; i < album.songs.Count; i++)
                                Console.WriteLine(i + ". " + album.getSong(i));
                            
                            Console.Write("\na: Album afspelen\nb: Album toevoegen aan " + playlist.playlistName + "\nc: Terug naar hoofdmenu\n\nIk wil: ");
                            userAction = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            if (userAction == "a")
                            {
                                for (int i = 0; i < album.songs.Count; i++)
                                {
                                    Console.WriteLine(album.playAlbum(i) + "\n");
                                    Console.WriteLine(album.getSongDuration(i));
                                }
                            } else if (userAction == "b")
                            {
                                playlist.addSong("Poesje Mauw", 2.01, "Meek Mill", "Gansta rap");
                                playlist.addSong("Ik houd van aardappelen", 7.01, "Meek Mill ft. Eminem", "Hip-hop");
                                playlist.addSong("Chocoladefontein", 3.33, "Meek Mill ft. Die Donkere Man van De Avondshow", "Liefdesliedje");
                                Console.WriteLine("Nummers toegevoegd\n\n--------------------------------------------------");
                            }
                        } else if (userAction != "c")
                        {
                            Console.WriteLine("\n--------------------------------------------------");
                            Console.WriteLine("\nInvalide keuze");
                            Console.WriteLine("\n--------------------------------------------------");
                        }
                        break;

                    // GEBRUIKERS ACTIE
                    case "c":
                        Console.WriteLine("\n--------------------------------------------------\n\nSpotify gebruikers:\n");

                        for (int i = 0; i < person.users.Count; i++)
                            Console.WriteLine(i + ". " + person.getUsers(i));
                        
                        Console.Write("\na: Gebruiker bekijken\nb: Terug naar hoofdmenu\n\nIk wil: ");
                        userAction = Console.ReadLine().ToLower();

                        if (userAction == "a")
                        {
                            string userSelection = "";
                            Console.Write("Bekijk gebruiker: ");
                            userSelection = Console.ReadLine();
                            string userOption = "";
                            Console.WriteLine("\n--------------------------------------------------");
                            List<string> userSelectionOptions = new List<string>(new string[] { "0", "1", "2", "3", "4" });
                            int userSelectionOptionExists = userSelectionOptions.IndexOf(userSelection);
                            
                            if (userSelectionOptionExists != -1)
                            {
                                Console.WriteLine("\n" + person.getUserInfo(Int32.Parse(userSelection)));
                                Console.Write("\na: Toevoegen als vriend\nb: Afspeellijst bekijken\n\nIk wil: ");
                                userOption = Console.ReadLine().ToLower();
                                
                                if (userOption == "a")
                                {
                                    Console.WriteLine("\n--------------------------------------------------\n");
                                    person.addFriend(person.getUsers(Int32.Parse(userSelection)));
                                    Console.WriteLine(person.getUsers(Int32.Parse(userSelection)) + " is toegevoegd als vriend.\n\n--------------------------------------------------");
                                } else if (userOption == "b")
                                {
                                    Console.WriteLine("\n--------------------------------------------------\n");
                                    Console.WriteLine(person.getUserPlaylist(Int32.Parse(userSelection)));
                                    Console.Write("a: Nummer afspelen\nb: Nummers toevoegen aan " + person.playlistName + "\n\nIk wil: ");
                                    string userSongAction = Console.ReadLine();

                                    if (userSongAction == "a")
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n");
                                        Console.WriteLine(person.playUserPlaylist(Int32.Parse(userSelection)));
                                    } else if (userSongAction == "b")
                                    {
                                        switch (userSelection)
                                        {
                                            default:
                                                playlist.addSong("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
                                                playlist.addSong("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
                                                Console.WriteLine("\nNummers toegevoegd\n\n--------------------------------------------------");
                                                break;
                                            case "1":
                                                playlist.addSong("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
                                                Console.WriteLine("\nNummers toegevoegd\n\n--------------------------------------------------");
                                                break;
                                            case "2":
                                                playlist.addSong("Nederlandse Volkslied", 5.11, "van der Sar", "Volkslied");
                                                Console.WriteLine("\nNummers toegevoegd\n\n--------------------------------------------------");
                                                break;
                                            case "3":
                                                playlist.addSong("Pietje Bel", 4.11, "Gerard Joling", "Liefdesliedje");
                                                playlist.addSong("Nederlandse Volkslied", 5.11, "van der Sar", "Volkslied");
                                                playlist.addSong("Schnappi de Kleine Krokodil", 3.07, "Jan Smit", "Kinderlied");
                                                Console.WriteLine("\nNummers toegevoegd\n\n--------------------------------------------------");
                                                break;
                                            case "4":
                                                playlist.addSong("Bob de Bouwer", 5.01, "Jan Janssen", "Cartoon lied");
                                                Console.WriteLine("\nNummers toegevoegd\n\n--------------------------------------------------");
                                                break;
                                    }
                                } else
                                    {
                                        Console.WriteLine("\n--------------------------------------------------\n\nInvalide keuze\n\n--------------------------------------------------");
                                    }
                                } else
                                {
                                    Console.Write("\n--------------------------------------------------\n\nInvalide keuze\n\n--------------------------------------------------");
                                }
                                break;
                            } else
                            {
                                Console.WriteLine("\nInvalide keuze");
                            }
                        }
                        Console.WriteLine("\n--------------------------------------------------");
                        break;

                    // VRIENDENLIJST OPHALEN
                    case "d":
                        Console.WriteLine("\n--------------------------------------------------\n\n" + person.name + " (" + person.friends.Count + " vrienden):\n");
                        if (person.friends.Count == 0)
                        {
                            Console.WriteLine("Het is nogal leeg hier, je wordt teruggestuurd naar de hoofdmenu...");
                        } else
                        {
                            for (int i = 0; i < person.friends.Count; i++)
                                Console.WriteLine(i + ". " + person.getFriends(i));
                        }
                        Console.WriteLine("\n--------------------------------------------------");
                        break;
                }
            }
        }
    }
}
