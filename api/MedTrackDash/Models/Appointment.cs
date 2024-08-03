namespace MedTrackDash.Models
{
	public class Appointment
	{
		/// <summary>
		/// Gets or sets the date and time of the appointment.
		/// </summary>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// Gets or sets the patient associated with the appointment.
		/// </summary>
		public Patient Patient { get; set; }

		/// <summary>
		/// Gets or sets the doctor associated with the appointment.
		/// </summary>
		public Doctor Doctor { get; set; }
	}
}