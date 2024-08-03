namespace MedTrackDash.Dtos
{
	/// <summary>
	/// Data transfer object representing a prescription.
	/// </summary>
	public class PrescriptionDto
	{
		/// <summary>
		/// Gets or sets the ID of the prescription.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the ID of the doctor who issued the prescription.
		/// </summary>
		public DoctorDto Doctor { get; set; }

		/// <summary>
		/// Gets or sets the ID of the medicine prescribed.
		/// </summary>
		public MedicineDto Medicine { get; set; }

		/// <summary>
		/// Gets or sets the date when the prescription was issued.
		/// </summary>
		public DateTime IssueDate { get; set; }

		/// <summary>
		/// Gets or sets the date when the prescription should be started.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the date when the prescription should end, if applicable.
		/// </summary>
		public DateTime? EndDate { get; set; }
	}
}
