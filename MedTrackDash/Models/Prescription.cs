namespace MedTrackDash.Dtos
{
	/// <summary>
	/// Represents a prescription issued to a patient by a doctor.
	/// </summary>
	public class Prescription
	{
		/// <summary>
		/// Gets or sets the ID of the prescription.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the ID of the patient for whom the prescription is made.
		/// </summary>
		public int PatientId { get; set; }

		/// <summary>
		/// Gets or sets the ID of the doctor who issued the prescription.
		/// </summary>
		public int DoctorId { get; set; }

		/// <summary>
		/// Gets or sets the ID of the medicine prescribed.
		/// </summary>
		public int MedicineId { get; set; }

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