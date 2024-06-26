﻿using MedTrackDash.Dtos;
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
				Doctor = prescription.Doctor.ToDto(),
				Medicine = prescription.Medicine.ToDto(),
				IssueDate = prescription.IssueDate,
				StartDate = prescription.StartDate,
				EndDate = prescription.EndDate
			};
		}
	}
}