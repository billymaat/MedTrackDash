namespace MedTrackDash.Dtos
{
	public class PatientUpdateDto
	{
		/// <summary>
		/// Gets or sets the ID of the patient.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the first name of the patient.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the surname of the patient.
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// Gets or sets the age of the patient.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Gets or sets the gender of the patient.
		/// </summary>
		public string Gender { get; set; }
	}

}
