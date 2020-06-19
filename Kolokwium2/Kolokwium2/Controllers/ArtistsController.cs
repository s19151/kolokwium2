using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.DTOs.Requests;
using Kolokwium2.DTOs.Responses;
using Kolokwium2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private EventDbContext _context;

        public ArtistsController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult getArtist(int id) {
            var artist = _context.Artist.SingleOrDefault(e => e.IdArtist == id);

            if (artist == null)
            {
                return NotFound("Brak artysty o podanym ID");
            }

            var response = new GetArtistResponse();
            response.IdArtist = artist.IdArtist;
            response.Nickname = artist.Nickname;

            response.Events = new List<GetEventResponse>();

            var artist_event = _context.Artist_Event.Where(e => e.IdArtist == id);

            if (artist_event.Count() > 0)
            {
                var artist_eventList = artist_event.ToList();
                for (int i = 0; i < artist_eventList.Count(); i++)
                {
                    var ae = artist_eventList[i];

                    var ev = _context.Event.Where(e => e.IdEvent == ae.IdEvent)
                        .SingleOrDefault();

                    if (ev != null)
                    {
                        var evRes = new GetEventResponse();

                        evRes.IdEvent = ev.IdEvent;
                        evRes.Name = ev.Name;
                        evRes.StartDate = ev.StartDate;
                        evRes.EndDate = ev.EndDate;

                        response.Events.Add(evRes);
                    }
                }
            }

            response.Events.OrderBy(e => e.StartDate);

            return Ok(response);
        }

        [HttpPost("{idA:int}/events/{idE:int}")]
        public IActionResult ModifyPerformanceDate(ModifyPerformanceDateRequest request)
        {
            var artist_event = _context.Artist_Event.SingleOrDefault
            (
                e => e.IdArtist == request.IdArtist &&
                e.IdEvent == request.IdEvent
            );

            if (artist_event == null)
            {
                return NotFound("Brak podanej asocjacji");
            }

            var ev = _context.Event.Where(e => e.IdEvent == artist_event.IdEvent)
                .SingleOrDefault();

            if (ev.StartDate.CompareTo(request.PerformanceDate) < 0 || ev.EndDate.CompareTo(request.PerformanceDate) > 0)
            {
                return BadRequest("Nowa data musi zawierać się w terminie trwania wydarzenia");
            }

            artist_event.PerfomanceDate = request.PerformanceDate;

            _context.SaveChanges();

            return Ok();
        }

    }
}