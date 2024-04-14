using MedTrackDash.Dtos;

namespace MedTrackDash.Services;

public interface IPatientDatabaseService
{
	Task AddPatient(PatientAddDto patientAddDto);
	Task<PatientDto> GetPatientById(int id);
	Task<List<PatientDto>> GetAllPatients();
	Task<bool> UpdatePatient(int id, PatientUpdateDto patientUpdateDto);
	Task<bool> DeletePatient(int id);

	Task<bool> AddPrescription(int patientId, PrescriptionAddDto prescriptionAddDto);

	Task<List<PrescriptionDto>?> GetPatientPrescriptions(int id);

	/// <summary>
	/// Retrieves all appointments associated with a specific patient.
	/// </summary>
	/// <param name="id">The ID of the patient.</param>
	/// <returns>A list of appointments associated with the patient, or null if the patient is not found.</returns>
	Task<List<AppointmentDto>?> GetPatientAppointments(int id);

	Task<List<PatientDto>> GetPatientsByIds(List<int> ids);
}