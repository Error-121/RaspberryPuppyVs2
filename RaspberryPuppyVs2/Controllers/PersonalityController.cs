using Microsoft.AspNetCore.Mvc;
using RaspberryPuppyVs2.Data.EFDbContext;
using RaspberryPuppyVs2.Models;
using RaspberryPuppyVs2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaspberryPuppyVs2.Controllers
{
	[Route("Personality")]

	[ApiController]

	public class PersonalityController : ControllerBase
	{
		private readonly PuppyDbContext _context;
		private readonly GenericPuppy<Personality> _personRepo;


		public PersonalityController(PuppyDbContext context, GenericPuppy<Personality> personRepo, GenericPuppy<TripData> tripRepo)
		{
			_context = context;
			_personRepo = personRepo;
		}

		[HttpGet]
		public IEnumerable<Personality> GetAllPerson()
		{
			return _personRepo.GetAll();
		}


		// GET api/<PuppyController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		public ActionResult<Personality> GetById(int id)
		{
			Personality aPerson = _personRepo.GetByID(id);
			if (aPerson == null)
			{
				return NotFound();
			}
			else
				return Ok(aPerson);
		}

		[HttpPost]
		public Personality Post([FromBody] Personality value)
		{
			return _personRepo.Add(value);
		}

		// PUT api/<PuppyController>/
		[HttpPut("{id}")]
		public Personality? Put(int id, [FromBody] Personality value)
		{
			return _personRepo.Update(id, value);
		}

		// DELETE api/<PuppyController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_personRepo.Delete(id);
		}
	}
}
