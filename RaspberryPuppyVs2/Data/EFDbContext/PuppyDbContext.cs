using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RaspberryPuppyVs2.Models;

namespace RaspberryPuppyVs2.Data.EFDbContext
{
	public class PuppyDbContext : DbContext 
	{
		public PuppyDbContext(DbContextOptions<PuppyDbContext> options): base(options)
		{
		}

		public DbSet<Personality> Personalities { get; set; }
		public DbSet<TripData> Trips { get; set; }
	}
}
