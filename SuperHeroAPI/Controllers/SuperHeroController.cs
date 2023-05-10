using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>()
            {
                new SuperHero {
                    Id = 1,
                    Name = "Spider-Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Ironman",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
                }
            };



        [HttpGet()]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroe(int id)
        {
            SuperHero? hero = heroes.Find(h => h.Id == id);
            if (hero != null)
                return Ok(hero);
            return BadRequest("Heroe not found.");
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut("TutorialPut")]
        public async Task<ActionResult<List<SuperHero>>> TutorialUpdateHero(SuperHero request)
        {
            SuperHero hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return NotFound($"Hero with id {request.Id} not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heroes);
        }

        [HttpPut("MyUpdate{id}")]
        public async Task<ActionResult<SuperHero>> myUpdate(int id, string? name, string? fName, string? lName, string? place)
        {
            SuperHero? hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return NotFound($"Hero with id {id} not found.");
            if (name != null)
                hero.Name = name;
            if (fName != null)
                hero.FirstName = fName;
            if (lName != null)
                hero.LastName = lName;
            if (place != null)
                hero.Place = place;


            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> deleteHero(int id)
        {
            SuperHero? hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return NotFound($"Hero with id {id} not found.");
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
