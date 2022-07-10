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
                               
            }
         };

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroe>>> Get()
        {
            
            return Ok(heroes);//codigo 200 todo bien
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroe>>> AddHeroe(SuperHeroe heroe)
        {
            heroes.Add(heroe);
            return Ok(heroes);//codigo 200 todo bien
        }
    }
}
