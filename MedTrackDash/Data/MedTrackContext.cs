using MedTrackDash.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedTrackDash.Data
{
	public class MedTrackContext : DbContext
	{
		public MedTrackContext(DbContextOptions<MedTrackContext> options) : base(options)
		{
		}

		public DbSet<PatientEntity> Patients { get; set; }
	}
}
