using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContainerApi.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        WeatherContext _context;
        public WeatherController(WeatherContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<WeatherEvent> Get()
        {
            return _context.WeatherEvents
                .Include(i => i.Reactions)
                .ThenInclude(t => t.Comments);
        }

        [HttpGet("{date}")]
        public IEnumerable<WeatherEvent> Get(DateTime date)
        {
            return _context.WeatherEvents.Where(w => w.Date.Date == date.Date)
                .Include(i => i.Reactions)
                .ThenInclude(t => t.Comments);
        }

        [HttpGet("{weatherType:int}")]
        public IEnumerable<WeatherEvent> Get(int weatherType)
        {
            return _context.WeatherEvents.FromSql($"SELECT * FROM EventsByType({weatherType})")
                .Include(i => i.Reactions)
                .ThenInclude(t => t.Comments);
        }
    }
}
