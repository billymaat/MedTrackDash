using MedTrackDash.Dtos;
using MedTrackDash.Entities;

namespace MedTrackDash.Extensions
{
	public static class PrescriptionMapper
	{
		/// <summary>
		/// Converts a PrescriptionEntity to a PrescriptionDto.
		/// </summary>
		/// <param name="prescription">The PrescriptionEntity to convert.</param>
		/// <returns>The converted PrescriptionDto.</returns>
		public static PrescriptionDto ToDto(this PrescriptionEntity prescription)
		{
			return new PrescriptionDto
			{
				Id = prescription.Id,
				PatientId = prescription.PatientId,
				DoctorId = prescription.DoctorId,
				MedicineId = prescription.MedicineId,
				IssueDate = prescription.IssueDate,
				StartDate = prescription.StartDate,
				EndDate = prescription.EndDate
			};
		}
	}
}