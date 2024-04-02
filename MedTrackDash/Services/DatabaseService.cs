using MedTrackDash.Data;
using MedTrackDash.Entities;
using MedTrackDash.Extensions;
using Microsoft.EntityFrameworkCore;
using MedTrackDash.Dtos;

public class DatabaseService : IDatabaseService
{
	private readonly MedTrackContext _context;
	private readonly ILogger<DatabaseService> _logger;

	public DatabaseService(MedTrackContext context, ILogger<DatabaseService> logger)
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
			Gender = patientAddDto.Gender
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

	public async Task UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
	{
		var patientEntity = await _context.Patients.FindAsync(id);
		if (patientEntity != null)
		{
			patientEntity.FirstName = patientUpdateDto.FirstName;
			patientEntity.Surname = patientUpdateDto.Surname;
			patientEntity.Age = patientUpdateDto.Age;
			patientEntity.Gender = patientUpdateDto.Gender; 
			
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
