using MedTrackDash.Models;

public interface IDatabaseService
{
	Task AddPatient(Patient patient);
	Task<Patient> GetPatientById(int id);
	Task<List<Patient>> GetAllPatients();
	Task UpdatePatient(int id, Patient updatedPatient);
	Task DeletePatient(int id);
}