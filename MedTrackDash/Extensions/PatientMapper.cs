using MedTrackDash.Dtos;
using MedTrackDash.Entities;
using MedTrackDash.Models;

namespace MedTrackDash.Extensions
{
	public static class PatientMapper
	{
		/// <summary>
		/// Converts a Patient object to a PatientDto object.
		/// </summary>
		/// <param name="patient">The Patient object to convert.</param>
		/// <returns>The corresponding PatientDto object.</returns>
		public static PatientDto ToDto(this Patient patient)
		{
			return new PatientDto
			{
				FirstName = patient.FirstName,
				Surname = patient.Surname,
				Age = patient.Age,
				Gender = (Dtos.Gender)patient.Gender
			};
		}

		/// <summary>
		/// Converts a PatientDto object to a Patient object.
		/// </summary>
		/// <param name="patientDto">The PatientDto object to convert.</param>
		/// <returns>The corresponding Patient object.</returns>
		public static Patient ToPatient(this PatientDto patientDto)
		{
			return new Patient
			{
				FirstName = patientDto.FirstName,
				Surname = patientDto.Surname,
				Age = patientDto.Age,
				Gender = (Models.Gender)patientDto.Gender
			};
		}

		/// <summary>
		/// Converts a Patient object to a PatientEntity object.
		/// </summary>
		/// <param name="patient">The Patient object to convert.</param>
		/// <returns>The corresponding PatientEntity object.</returns>
		public static PatientEntity ToPatientEntity(this Patient patient)
		{
			return new PatientEntity
			{
				FirstName = patient.FirstName,
				Surname = patient.Surname,
				Age = patient.Age,
				Gender = (Entities.Gender)patient.Gender
			};
		}

		/// <summary>
		/// Converts a PatientEntity object to a Patient object.
		/// </summary>
		/// <param name="patientEntity">The PatientEntity object to convert.</param>
		/// <returns>The corresponding Patient object.</returns>
		public static Patient ToPatient(this PatientEntity patientEntity)
		{
			return new Patient
			{
				FirstName = patientEntity.FirstName,
				Surname = patientEntity.Surname,
				Age = patientEntity.Age,
				Gender = (Models.Gender)patientEntity.Gender
			};
		}

		/// <summary>
		/// Converts a PatientEntity object to a Patient object.
		/// </summary>
		/// <param name="patientEntity">The PatientEntity object to convert.</param>
		/// <returns>The corresponding Patient object.</returns>
		public static PatientDto ToDto(this PatientEntity patientEntity)
		{
			return new PatientDto
			{
				FirstName = patientEntity.FirstName,
				Surname = patientEntity.Surname,
				Age = patientEntity.Age,
				Gender = (Dtos.Gender)patientEntity.Gender
			};
		}
	}
}
