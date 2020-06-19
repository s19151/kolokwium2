using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Event
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Artist_Event> Artists_Events { get; set; }
        public virtual ICollection<Event_Organiser> Events_Organisers { get; set; }
    }
}
