using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroeAPI.Data;
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
        private readonly DataContext _context;
    

        public SuperHeroeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroe>>> Get()
        {

            return Ok(await _context.Superheroes.ToListAsync());//codigo 200 todo bien
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHeroe>>> Get(int id)
        {
            var heroe = await _context.Superheroes.FindAsync(id);
            if (heroe == null)
            {
                return BadRequest("No se encontro id");
            }
            return Ok(heroe);//codigo 200 todo bien
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroe>>> AddHeroe(SuperHeroe heroe)
        {
             _context.Superheroes.Add(heroe);
            await _context.SaveChangesAsync();//codigo 200 todo bien
            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroe>>> UpdateHeroe(SuperHeroe request)
        {
            var dbheroe =  await _context.Superheroes.FindAsync(request.Id);
            if (dbheroe == null)
            {
                return BadRequest("No se encontro id");
            }
            dbheroe.Name = request.Name;
            dbheroe.FirstName = request.FirstName;
            dbheroe.LastName = request.LastName;
            dbheroe.Place = request.Place;
            await _context.SaveChangesAsync();  
            return Ok(await _context.Superheroes.ToListAsync());//codigo 200 todo bien
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroe>>> DeleteHeroe(int id)
        {
            var dbheroe = await _context.Superheroes.FindAsync(id);
            if (dbheroe == null)
            {
                return BadRequest("No se encontro id");
            }
            _context.Superheroes.Remove(dbheroe);
            await _context.SaveChangesAsync();
            return Ok(await _context.Superheroes.ToListAsync());//codigo 200 todo bien
        }
    }
}
