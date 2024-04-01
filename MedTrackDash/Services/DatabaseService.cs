using MedTrackDash.Data;
using MedTrackDash.Entities;
using MedTrackDash.Models;
using MedTrackDash.Extensions;
using Microsoft.EntityFrameworkCore;

public class DatabaseService
{
	private readonly MedTrackContext _context;
	private readonly ILogger<DatabaseService> _logger;

	public DatabaseService(MedTrackContext context, ILogger<DatabaseService> logger)
	{
		_context = context;
		_logger = logger;
	}

	public async Task AddPatient(Patient patient)
	{
		PatientEntity patientEntity = patient.ToPatientEntity();
		_context.Patients.Add(patientEntity);
		await _context.SaveChangesAsync();
		_logger.LogInformation("Patient added to the database.");
	}

	public async Task<Patient> GetPatientById(int id)
	{
		PatientEntity patientEntity = await _context.Patients.FindAsync(id);
		if (patientEntity != null)
		{
			return patientEntity.ToPatient();
		}
		_logger.LogInformation("Patient not found in the database.");
		return null;
	}

	public async Task<List<Patient>> GetAllPatients()
	{
		var patients = await _context.Patients
			.Select(p => p.ToPatient())
			.ToListAsync();
		_logger.LogInformation("Retrieved all patients from the database.");
		return patients;
	}

	public async Task UpdatePatient(int id, Patient updatedPatient)
	{
		PatientEntity patientEntity = await _context.Patients.FindAsync(id);
		if (patientEntity != null)
		{
			patientEntity.FirstName = updatedPatient.FirstName;
			patientEntity.Surname = updatedPatient.Surname;
			patientEntity.Age = updatedPatient.Age;
			patientEntity.Gender = updatedPatient.Gender; 
			
			await _context.SaveChangesAsync();
			_logger.LogInformation("Patient information updated in the database.");
		}
		else
		{
			_logger.LogInformation("Patient not found in the database.");
		}
	}

	public async Task DeletePatient(int id)
	{
		PatientEntity patientEntity = await _context.Patients.FindAsync(id);
		if (patientEntity != null)
		{
			_context.Patients.Remove(patientEntity);
			await _context.SaveChangesAsync();
			_logger.LogInformation("Patient deleted from the database.");
		}
		else
		{
			_logger.LogInformation("Patient not found in the database.");
		}
	}
}
