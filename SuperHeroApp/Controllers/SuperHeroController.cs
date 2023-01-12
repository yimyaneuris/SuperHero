using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>()
        {
            new SuperHero()
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York"

            }
        };

        public SuperHeroController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var heroe = heroes.Find(h => h.Id == id);

            return Ok(heroe);
        }

        [HttpPost]
        public async Task<ActionResult> Post(SuperHero heroe)
        {
            heroes.Add(heroe);

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var heroe = heroes.Find(h => h.Id == id);

            if (heroe != null)
            {
                heroes.Remove(heroe);
            }

            return Ok(heroes);
        }
    }
}

