using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaspberryPuppyVs2.Models
{
	public class TripData
	{
		public TripData()
		{

		}
		public TripData(int tagNr, string? location, int temperature, int timeOutside)
		{
			TagNr = tagNr;
			Location = location;
			Temperature = temperature;
			TimeOutside = timeOutside;
		}

		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Personality")]
		[Required]
		public int TagNr { get; set; }
		
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string? Location { get; set; }
		[Required]
		public int Temperature { get; set; }
		[Required]
		public int TimeOutside { get; set; }

		public Personality Personality { get; set; }
	}
}
