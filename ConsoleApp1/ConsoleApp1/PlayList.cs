using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Playlist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }
    }
}
