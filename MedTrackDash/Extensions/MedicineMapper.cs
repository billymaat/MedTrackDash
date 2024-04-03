using MedTrackDash.Dtos;
using MedTrackDash.Entities;

namespace MedTrackDash.Extensions
{
	public static class MedicineMapper
	{
		/// <summary>
		/// Converts a MedicineDto object to a MedicineEntity object.
		/// </summary>
		/// <param name="medicineDto">The MedicineDto to convert.</param>
		/// <returns>The converted MedicineEntity object.</returns>
		public static MedicineEntity ToEntity(this MedicineDto medicineDto)
		{
			return new MedicineEntity
			{
				Id = medicineDto.Id,
				Name = medicineDto.Name,
				Description = medicineDto.Description,
				Route = medicineDto.Route
			};
		}
	}
}
