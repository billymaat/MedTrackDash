using MedTrackDash.Models;

namespace MedTrackDash.Dtos
{
	/// <summary>
	/// Data transfer object representing a prescription.
	/// </summary>
	public class PrescriptionAddDto
	{
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

		public int DoctorId { get; set; }
	}
}