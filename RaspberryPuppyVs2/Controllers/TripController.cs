using Microsoft.AspNetCore.Mvc;
using RaspberryPuppyVs2.Data.EFDbContext;
using RaspberryPuppyVs2.Models;
using RaspberryPuppyVs2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaspberryPuppyVs2.Controllers
{
	[Route("Trip")]

	[ApiController]

	public class TripController : ControllerBase
	{
		private readonly PuppyDbContext _context;
		private readonly GenericPuppy<TripData> _tripRepo;


		public TripController(PuppyDbContext context, GenericPuppy<TripData> tripRepo)
		{
			_context = context;
			_tripRepo = tripRepo;
		}

		[HttpGet]
		public IEnumerable<TripData> GetAllTrips()
		{
			return _tripRepo.GetAll();
		}


		// GET api/<PuppyController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		public ActionResult<TripData> GetById(int id)
		{
			TripData? aTrip = _tripRepo.GetByID(id);
			if (aTrip == null)
			{
				return NotFound();
			}
			else
				return Ok(aTrip);
		}

		[HttpPost]
		public TripData Post([FromBody] TripData value)
		{
			return _tripRepo.Add(value);
		}

		// PUT api/<PuppyController>/
		[HttpPut("{id}")]
		public TripData? Put(int id, [FromBody] TripData value)
		{
			return _tripRepo.Update(id, value);
		}

		// DELETE api/<PuppyController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_tripRepo.Delete(id);
		}
	}
}
