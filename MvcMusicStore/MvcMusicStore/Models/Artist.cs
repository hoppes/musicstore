using System.ComponentModel;

namespace MvcMusicStore.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [DisplayName("Artist")]
        public string Name{ get; set; }
    }
}