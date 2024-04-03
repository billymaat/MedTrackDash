namespace MedTrackDash.Entities
{
	public class PatientEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }

		/// <summary>
		/// The Doctor foreign key property
		/// </summary>
		public int? DoctorId { get; set; }

		/// <summary>
		/// The Doctor reference navigation
		/// </summary>
		public DoctorEntity? Doctor { get; set; } = null!;

		/// <summary>
		/// Gets or sets the patient's appointments.
		/// </summary>
		public List<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
	}
}
