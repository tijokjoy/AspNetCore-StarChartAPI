using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{

    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int Id)
        {
            var celestrialobject = _context.CelestialObjects.Find(Id);

            if (celestrialobject == null)        return NotFound();

            celestrialobject.Satellites = _context.CelestialObjects.Where(x => x.OrbitedObjectId == Id).ToList();
            return Ok(celestrialobject);

        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string Name) {

            var celestrailObjects = _context.CelestialObjects.Where(x=> x.Name == Name).ToList();

            if (celestrailObjects ==null)    return NotFound();

            foreach (var item in celestrailObjects)
            {
                item.Satellites = _context.CelestialObjects.Where(x => x.OrbitedObjectId == item.Id).ToList();
             }
                return Ok(celestrailObjects);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var celestrialObjectS = _context.CelestialObjects.ToList();

            foreach (var item in celestrialObjectS)
            {
                item.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == item.Id).ToList();
            }
            return Ok(celestrialObjectS);

        }

        
    }
}
