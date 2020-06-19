using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.DTOs.Requests
{
    public class ModifyPerformanceDateRequest
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
