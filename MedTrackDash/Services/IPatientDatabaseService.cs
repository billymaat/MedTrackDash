using MedTrackDash.Dtos;

namespace MedTrackDash.Services;

public interface IPatientDatabaseService
{
	Task AddPatient(PatientAddDto patientAddDto);
	Task<PatientDto> GetPatientById(int id);
	Task<List<PatientDto>> GetAllPatients();
	Task<bool> UpdatePatient(int id, PatientUpdateDto patientUpdateDto);
	Task<bool> DeletePatient(int id);
}