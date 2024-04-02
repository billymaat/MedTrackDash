﻿namespace MedTrackDash.Entities
{
	public class DoctorEntity
	{
		/// <summary>
		/// Gets or sets the ID of the doctor.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the first name of the doctor.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the doctor.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the specialty of the doctor.
		/// </summary>
		public string Specialty { get; set; }

		/// <summary>
		/// Gets or sets the patients of the doctor
		/// </summary>
		public ICollection<PatientEntity> Patients { get; } = new List<PatientEntity>();
	}
}
