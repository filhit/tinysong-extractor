using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractPlaylistFromTinySong
{
    public class Song
    {
        public string Url { get; set; }

        public int SongID { get; set; }

        public string SongName { get; set; }

        public int ArtistID { get; set; }

        public string ArtistName { get; set; }

        public int AlbumID { get; set; }

        public string AlbumName { get; set; }
    }
}
