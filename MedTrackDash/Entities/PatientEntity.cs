namespace MedTrackDash.Entities
{
	public class PatientEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }

		/// <summary>
		/// The Doctor foreign key property
		/// </summary>
		public int? DoctorId { get; set; }

		/// <summary>
		/// The Doctor reference navigation
		/// </summary>
		public DoctorEntity? Doctor { get; set; } = null!;
	}
}
