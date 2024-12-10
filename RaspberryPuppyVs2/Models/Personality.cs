using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaspberryPuppyVs2.Models
{
	public class Personality
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TagNr { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string Name { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public int Age { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string Race { get; set; }
		[Required]
		public string Temperament { get; set; }


		public Personality()
		{

		}

		public Personality(int tagNr, string name, string race, int age, string temperament, string gender)
		{
			TagNr = tagNr;
			Name = name;
			Gender = gender;
			Age = age;
			Race = race;
			Temperament = temperament;
		}

		public override string ToString()
		{
			return $"{{{nameof(TagNr)}={TagNr}, {nameof(Name)}={Name}, {nameof(Gender)}={Gender}, {nameof(Age)}={Age}, {nameof(Race)}={Race}, {nameof(Name)}={Name.ToString()}}}";
		}

		public void ValidateName()
		{
			if (string.IsNullOrEmpty(Name))
			{
				throw new ArgumentNullException("Name is required");
			}

			else if (Name.Length < 2 || Name.Length > 50)
			{
				throw new ArgumentOutOfRangeException("Name must have at least 2 characters");
			}
			else if (false == Name.All(char.IsLetter))
			{
				throw new FormatException("Name cannot contain special characters nor numbers");
			}
		}

		public void ValidateRace()
		{
			if (string.IsNullOrEmpty(Race))
			{
				throw new ArgumentNullException("Race is required");
			}
			else if (Race.Length < 2 || Race.Length > 50)
			{
				throw new ArgumentOutOfRangeException("Race must be atleast 2 characters");
			}
			else if (false == Race.All(char.IsLetter))
			{
				throw new FormatException("Race cannot contain special characters nor numbers");
			}
		}

		public void ValidateValidate()
		{
			ValidateName();
			ValidateRace();
		}


	}
}
