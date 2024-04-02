using MedTrackDash.Dtos;

public interface IDatabaseService
{
	Task AddPatient(PatientAddDto patientAddDto);
	Task<PatientDto> GetPatientById(int id);
	Task<List<PatientDto>> GetAllPatients();
	Task UpdatePatient(int id, PatientUpdateDto patientUpdateDto);
	Task DeletePatient(int id);
}