using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData
            (
                new Artist { IdArtist = 1, Nickname = "Artist1"},
                new Artist { IdArtist = 2, Nickname = "Artist2" },
                new Artist { IdArtist = 3, Nickname = "Artist3" },
                new Artist { IdArtist = 4, Nickname = "Artist4" }
            );

            modelBuilder.Entity<Event>().HasData
            (
                new Event { IdEvent = 1, Name = "Event1", StartDate = DateTime.Parse("01.01.2020"), EndDate = DateTime.Parse("02.01.2020") },
                new Event { IdEvent = 2, Name = "Event2", StartDate = DateTime.Parse("01.02.2020"), EndDate = DateTime.Parse("02.02.2020") },
                new Event { IdEvent = 3, Name = "Event3", StartDate = DateTime.Parse("01.03.2020"), EndDate = DateTime.Parse("02.03.2020") },
                new Event { IdEvent = 4, Name = "Event4", StartDate = DateTime.Parse("01.04.2020"), EndDate = DateTime.Parse("02.04.2020") },
                new Event { IdEvent = 5, Name = "Event5", StartDate = DateTime.Parse("01.05.2020"), EndDate = DateTime.Parse("02.05.2020") }
            );

            modelBuilder.Entity<Organiser>().HasData
            (
                new Organiser { IdOrganiser = 1, Name = "Organiser1"},
                new Organiser { IdOrganiser = 2, Name = "Organiser2" },
                new Organiser { IdOrganiser = 3, Name = "Organiser3" },
                new Organiser { IdOrganiser = 4, Name = "Organiser4" }
            );

            modelBuilder.Entity<Artist_Event>().HasData
            (
                new Artist_Event { IdArtist = 1, IdEvent = 1, PerfomanceDate = DateTime.Parse("02.01.2020") },
                new Artist_Event { IdArtist = 2, IdEvent = 2, PerfomanceDate = DateTime.Parse("02.02.2020") },
                new Artist_Event { IdArtist = 3, IdEvent = 1, PerfomanceDate = DateTime.Parse("01.01.2020") },
                new Artist_Event { IdArtist = 3, IdEvent = 3, PerfomanceDate = DateTime.Parse("01.03.2020") }
            );

            modelBuilder.Entity<Event_Organiser>().HasData
            (
                new Event_Organiser { IdEvent = 1, IdOrganiser = 1 },
                new Event_Organiser { IdEvent = 2, IdOrganiser = 2 },
                new Event_Organiser { IdEvent = 3, IdOrganiser = 2 },
                new Event_Organiser { IdEvent = 4, IdOrganiser = 4 }
            );
        }
    }
}
