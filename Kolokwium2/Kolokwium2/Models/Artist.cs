using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<Artist_Event> Artists_Events { get; set; }
    }
}
