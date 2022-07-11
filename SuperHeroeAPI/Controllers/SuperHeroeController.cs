using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroeAPI.Models;

namespace SuperHeroeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroeController : ControllerBase
    {
        private static List<SuperHeroe> heroes = new List<SuperHeroe>
        {
            new SuperHeroe{

                    Id=1,
                    Name="Spiderman",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York",

            },
            new SuperHeroe{

                    Id=2,
                    Name="Hulk",
                    FirstName="Hector",
                    LastName="Perez",
                    Place="California",

            }
         };

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroe>>> Get()
        {

            return Ok(heroes);//codigo 200 todo bien
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHeroe>>> Get(int id)
        {
            var heroe = heroes.Find(h => h.Id == id);
            if (heroe == null)
            {
                return BadRequest("No se encontro id");
            }
            return Ok(heroe);//codigo 200 todo bien
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroe>>> AddHeroe(SuperHeroe heroe)
        {
            heroes.Add(heroe);
            return Ok(heroes);//codigo 200 todo bien
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroe>>> UpdateHeroe(SuperHeroe request)
        {
            var heroe = heroes.Find(h => h.Id == request.Id);
            if (heroe == null)
            {
                return BadRequest("No se encontro id");
            }
            heroe.Name = request.Name;
            heroe.FirstName = request.FirstName;
            heroe.LastName = request.LastName;
            heroe.Place = request.Place;
            return Ok(heroes);//codigo 200 todo bien
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroe>>> DeleteHeroe(int id)
        {
            var heroe = heroes.Find(h => h.Id == id);
            if (heroe == null)
            {
                return BadRequest("No se encontro id");
            }
            heroes.Remove(heroe);
            return Ok(heroes);//codigo 200 todo bien
        }
    }
}
