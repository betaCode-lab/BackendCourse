using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.people;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.people.FirstOrDefault(p => p.Id == id);

            if(people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.people.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.people.Add(people);

            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> people = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Adrian",
                Birthdate = new DateTime(2003, 02, 07)
            },
            new People()
            {
                Id = 2,
                Name = "Luis",
                Birthdate = new DateTime(2003, 10, 26)
            },
            new People()
            {
                Id = 3,
                Name = "Edgar",
                Birthdate = new DateTime(2003, 05, 16)
            },
            new People()
            {
                Id = 4,
                Name = "Fernanda",
                Birthdate = new DateTime(2010, 01, 01)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
