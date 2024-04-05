using MedTrackDash.Dtos;
using MedTrackDash.Entities;

namespace MedTrackDash.Extensions
{
	public static class DoctorMapper
	{
		public static DoctorDto ToDto(this DoctorEntity doctorEntity)
		{
			return new DoctorDto
			{
				Id = doctorEntity.Id,
				FirstName = doctorEntity.FirstName,
				LastName = doctorEntity.LastName,
				Specialty = doctorEntity.Specialty
			};
		}
	}
}
