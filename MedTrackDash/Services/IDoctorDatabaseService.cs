using MedTrackDash.Dtos;

namespace MedTrackDash.Services
{
	public interface IDoctorDatabaseService
	{
		Task AddDoctor(DoctorAddDto doctorAddDto);
		Task<DoctorDto> GetDoctorById(int id);
		Task<List<DoctorDto>> GetAllDoctors();
		Task<bool> UpdateDoctor(int id, DoctorUpdateDto doctorUpdateDto);
		Task<bool> DeleteDoctor(int id);
	}
}
