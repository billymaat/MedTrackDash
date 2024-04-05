using MedTrackDash.Data;
using MedTrackDash.Dtos;
using MedTrackDash.Entities;
using MedTrackDash.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MedTrackDash.Services;

public class PatientDatabaseService : IPatientDatabaseService
{
	private readonly MedTrackContext _context;
	private readonly ILogger<PatientDatabaseService> _logger;

	public PatientDatabaseService(MedTrackContext context, ILogger<PatientDatabaseService> logger)
	{
		_context = context;
		_logger = logger;

		if (!_context.Patients.Any())
		{
			SeedData.Seed(context);
		}
	}

	public async Task AddPatient(PatientAddDto patientAddDto)
	{
		var patientEntity = new PatientEntity()
		{
			FirstName = patientAddDto.FirstName,
			Surname = patientAddDto.Surname,
			Age = patientAddDto.Age,
			Gender = (Entities.Gender)patientAddDto.Gender
		};

		_context.Patients.Add(patientEntity);
		await _context.SaveChangesAsync();
		_logger.LogInformation("Patient added to the database.");
	}

	public async Task<PatientDto> GetPatientById(int id)
	{
		var patientEntity = await _context.Patients
			.Where(p => p.Id == id)
			.FirstOrDefaultAsync();

		if (patientEntity != null)
		{
			return patientEntity.ToDto();
		}

		_logger.LogInformation("Patient not found in the database.");
		return null;
	}

	public async Task<List<PatientDto>> GetAllPatients()
	{
		var patients = await _context.Patients
			.Select(p => p.ToDto())
			.ToListAsync();
		_logger.LogInformation("Retrieved all patients from the database.");
		return patients;
	}

	public async Task<bool> UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
	{
		var patientEntity = await _context.Patients
			.Where(p => p.Id == id)
			.FirstOrDefaultAsync();

		if (patientEntity != null)
		{
			patientEntity.FirstName = patientUpdateDto.FirstName;
			patientEntity.Surname = patientUpdateDto.Surname;
			patientEntity.Age = patientUpdateDto.Age;
			patientEntity.Gender = (Entities.Gender)patientUpdateDto.Gender; 
			
			await _context.SaveChangesAsync();
			_logger.LogInformation("Patient information updated in the database.");
			return true;
		}
		
		_logger.LogInformation("Patient not found in the database.");
		return false;
	}

	public async Task<bool> DeletePatient(int id)
	{
		PatientEntity patientEntity = await _context.Patients.FindAsync(id);
		if (patientEntity != null)
		{
			_context.Patients.Remove(patientEntity);
			await _context.SaveChangesAsync();
			_logger.LogInformation("Patient deleted from the database.");
			return true;
		}

		_logger.LogInformation("Patient not found in the database.");
		return false;
	}

	public async Task<bool> AddPrescription(int patientId, PrescriptionAddDto prescriptionAddDto)
	{
		// Retrieve the patient entity from the database
		var patientEntity = await _context.Patients.FindAsync(patientId);

		if (patientEntity == null)
		{
			// Handle the case when the patient is not found
			return false;
		}

		var medicine = prescriptionAddDto.Medicine.ToEntity();
		
		_context.Medicines.Add(medicine);

		// Create a new PrescriptionEntity and populate it with the provided data
		var prescriptionEntity = new PrescriptionEntity
		{
			PatientId = patientId,
			DoctorId = prescriptionAddDto.DoctorId,
			Medicine = medicine,
			IssueDate = DateTime.UtcNow,
			StartDate = prescriptionAddDto.StartDate,
			EndDate = prescriptionAddDto.EndDate
		};

		// Add the prescription entity to the context
		_context.Prescriptions.Add(prescriptionEntity);

		// Save changes to the database
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<List<PrescriptionDto>?> GetPatientPrescriptions(int id)
	{
		var prescriptions = await _context.Patients
			.Where(p => p.Id == id)
			.Include(p => p.Prescriptions)
			.ThenInclude(p => p.Medicine)
			.Include(p => p.Prescriptions)
			.ThenInclude(p => p.Doctor)
			.Select(p => new
			{
				Prescription = p.Prescriptions.Select(p => p.ToDto())
			})
			.FirstOrDefaultAsync();

		return prescriptions?.Prescription.ToList();
	}

	/// <summary>
	/// Retrieves all appointments associated with a specific patient.
	/// </summary>
	/// <param name="id">The ID of the patient.</param>
	/// <returns>A list of appointments associated with the patient, or null if the patient is not found.</returns>
	public async Task<List<AppointmentDto>?> GetPatientAppointments(int id)
	{
		var appointments = await _context.Patients
			.Where(p => p.Id == id)
			.Select(p => new
			{
				Appointments = p.Appointments.Select(a => a.ToDto())
			})
			.FirstOrDefaultAsync();

		return appointments?.Appointments.ToList();
	}
}