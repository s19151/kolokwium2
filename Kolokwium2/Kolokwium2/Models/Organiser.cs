using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event_Organiser> Events_Organisers { get; set; }
    }
}
