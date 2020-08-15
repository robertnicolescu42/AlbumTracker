using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumTracker.ModelView
{
    public class AlbumTrackerView
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumDescription { get; set; }
        public int AlbumRating { get; set; }
        public int? AlbumYear { get; set; }
    }
}
