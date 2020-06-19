using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.DTOs.Responses
{
    public class GetArtistResponse
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public ICollection<GetEventResponse> Events { get; set; }
    }
}
