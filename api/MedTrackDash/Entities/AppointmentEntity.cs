namespace MedTrackDash.Entities
{
	public class AppointmentEntity
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
		/// Gets or sets the patient associated with the appointment.
		/// </summary>
		public PatientEntity Patient { get; set; }

		/// <summary>
		/// Gets or sets the ID of the doctor associated with the appointment.
		/// </summary>
		public int DoctorId { get; set; }

		/// <summary>
		/// Gets or sets the doctor associated with the appointment.
		/// </summary>
		public DoctorEntity Doctor { get; set; }
	}
}
