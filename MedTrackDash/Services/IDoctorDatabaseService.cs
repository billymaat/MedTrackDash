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
		Task<List<PatientDto>?> GetDoctorPatientsById(int id);
		/// <summary>
		/// Retrieves all appointments associated with a specific doctor.
		/// </summary>
		/// <param name="id">The ID of the doctor.</param>
		/// <returns>A list of appointments associated with the doctor, or null if the doctor is not found.</returns>
		Task<List<AppointmentDto>?> GetDoctorAppointments(int id);
	}
}
