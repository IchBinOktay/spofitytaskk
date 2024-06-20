using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public List<Playlist> Playlists { get; set; }

        public User(string username, string password, UserType userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
            Playlists = new List<Playlist>();
        }
    }
}
