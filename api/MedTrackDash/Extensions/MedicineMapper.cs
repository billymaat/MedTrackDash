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

		/// <summary>
		/// Converts a MedicineEntity object to a MedicineDto object.
		/// </summary>
		/// <param name="medicineEntity">The MedicineEntity to convert.</param>
		/// <returns>The converted MedicineDto object.</returns>
		public static MedicineDto ToDto(this MedicineEntity medicineEntity)
		{
			return new MedicineDto
			{
				Id = medicineEntity.Id,
				Name = medicineEntity.Name,
				Description = medicineEntity.Description,
				Route = medicineEntity.Route
			};
		}
	}
}
