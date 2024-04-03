namespace MedTrackDash.Dtos
{
	public class AppointmentDto
	{
		/// <summary>
		/// Gets or sets the ID of the appointment.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the date and time of the appointment.
		/// </summary>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// Gets or sets the ID of the patient associated with the appointment.
		/// </summary>
		public int PatientId { get; set; }

		/// <summary>
		/// Gets or sets the ID of the doctor associated with the appointment.
		/// </summary>
		public int DoctorId { get; set; }
	}
}
