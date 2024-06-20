using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public enum UserType
    {
        Standard,
        Premium
    }

public class Program
    {
        static void Main(string[] args)
        {
            Log log = new Log();

            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register(log);
                        break;
                    case "2":
                        User user = Login(log);
                        if (user != null)
                        {
                            ManagePlaylists(user);
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void Register(Log log)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter user type (1 for Standard, 2 for Premium):");
            UserType userType = Console.ReadLine() == "1" ? UserType.Standard : UserType.Premium;

            log.Register(username, password, userType);
        }

        static User Login(Log log)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            return log.Login(username, password);
        }

        static void ManagePlaylists(User user)
        {
            while (true)
            {
                Console.WriteLine("1. Create Playlist");
                Console.WriteLine("2. View Playlists");
                Console.WriteLine("3. Add Song to Playlist");
                Console.WriteLine("4. Logout");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreatePlaylist(user);
                        break;
                    case "2":
                        ViewPlaylists(user);
                        break;
                    case "3":
                        AddSongToPlaylist(user);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreatePlaylist(User user)
        {
            Console.WriteLine("Enter playlist name:");
            string name = Console.ReadLine();
            user.Playlists.Add(new Playlist(name));
            Console.WriteLine("Playlist created successfully.");
        }

        static void ViewPlaylists(User user)
        {
            foreach (var playlist in user.Playlists)
            {
                Console.WriteLine($"Playlist: {playlist.Name}");
                foreach (var song in playlist.Songs)
                {
                    Console.WriteLine($" - {song.Title} by {song.Artist}");
                }
            }
        }

        static void AddSongToPlaylist(User user)
        {
            Console.WriteLine("Enter playlist name:");
            string playlistName = Console.ReadLine();
            Playlist playlist = user.Playlists.Find(p => p.Name == playlistName);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.WriteLine("Enter song title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter song artist:");
            string artist = Console.ReadLine();

            playlist.Songs.Add(new Song(title, artist));
            Console.WriteLine("Song added successfully.");
        }
    }

}