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
		public DbSet<DoctorEntity> Doctors { get; set; }
		public DbSet<AppointmentEntity> Appointments { get; set; }
		public DbSet<PrescriptionEntity> Prescriptions { get; set; }
		public DbSet<MedicineEntity> Medicines { get; set; }
	}
}
