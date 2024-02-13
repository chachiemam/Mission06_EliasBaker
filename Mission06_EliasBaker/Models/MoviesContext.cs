using Microsoft.EntityFrameworkCore;

namespace Mission06_EliasBaker.Models
{
	public class MoviesContext : DbContext
	{
		public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) 
		{ }
		public DbSet<Collection> movies { get; set; }
	}
}
