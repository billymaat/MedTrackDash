using MedTrackDash.Data;
using MedTrackDash.Dtos;
using MedTrackDash.Entities;
using MedTrackDash.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MedTrackDash.Services
{
	public class DoctorDatabaseService : IDoctorDatabaseService
	{
		private readonly MedTrackContext _context;
		private readonly ILogger<DoctorDatabaseService> _logger;

		public DoctorDatabaseService(MedTrackContext context, ILogger<DoctorDatabaseService> logger)
		{
			_context = context;
			_logger = logger;

			if (!_context.Doctors.Any())
			{
				SeedData.Seed(context);
			}
		}

		public async Task AddDoctor(DoctorAddDto doctorAddDto)
		{
			var doctorEntity = new DoctorEntity()
			{
				FirstName = doctorAddDto.FirstName,
				LastName = doctorAddDto.LastName,
				Specialty = doctorAddDto.Specialty
			};

			_context.Doctors.Add(doctorEntity);
			await _context.SaveChangesAsync();
			_logger.LogInformation("Doctor added to the database.");
		}

		public async Task<DoctorDto> GetDoctorById(int id)
		{
			var doctorEntity = await _context.Doctors
				.Where(d => d.Id == id)
				.FirstOrDefaultAsync();

			if (doctorEntity != null)
			{
				return doctorEntity.ToDto();
			}

			_logger.LogInformation("Doctor not found in the database.");
			return null;
		}

		public async Task<List<PatientDto>?> GetDoctorPatientsById(int id)
		{
			var doc = await _context.Doctors
				.Where(d => d.Id == id)
				.Select(d => new {
					Patients = d.Patients.Select(p => p.ToDto())
				})
				.FirstOrDefaultAsync();

			return doc?.Patients.ToList();
		}

		/// <summary>
		/// Retrieves all appointments associated with a specific doctor.
		/// </summary>
		/// <param name="id">The ID of the doctor.</param>
		/// <returns>A list of appointments associated with the doctor, or null if the doctor is not found.</returns>
		public async Task<List<AppointmentDto>?> GetDoctorAppointments(int id)
		{
			var appointments = await _context.Doctors
				.Where(p => p.Id == id)
				.Select(p => new
				{
					Appointments = p.Appointments.Select(a => a.ToDto())
				})
				.FirstOrDefaultAsync();

			return appointments?.Appointments.ToList();
		}

		public async Task<List<DoctorDto>> GetAllDoctors()
		{
			var doctors = await _context.Doctors
				.Select(d => d.ToDto())
				.ToListAsync();
			_logger.LogInformation("Retrieved all doctors from the database.");
			return doctors;
		}

		public async Task<bool> UpdateDoctor(int id, DoctorUpdateDto doctorUpdateDto)
		{
			var doctorEntity = await _context.Doctors
				.Where(d => d.Id == id)
				.FirstOrDefaultAsync();

			if (doctorEntity != null)
			{
				doctorEntity.FirstName = doctorUpdateDto.FirstName;
				doctorEntity.LastName = doctorUpdateDto.LastName;
				doctorEntity.Specialty = doctorUpdateDto.Specialty;

				await _context.SaveChangesAsync();
				_logger.LogInformation("Doctor information updated in the database.");
				return true;
			}

			_logger.LogInformation("Doctor not found in the database.");
			return false;
		}

		public async Task<bool> DeleteDoctor(int id)
		{
			var doctorEntity = await _context.Doctors.FindAsync(id);
			if (doctorEntity != null)
			{
				_context.Doctors.Remove(doctorEntity);
				await _context.SaveChangesAsync();
				_logger.LogInformation("Doctor deleted from the database.");
				return true;
			}

			_logger.LogInformation("Doctor not found in the database.");
			return false;
		}
	}

}
