using MedTrackDash.Data;
using MedTrackDash.Dtos;
using MedTrackDash.Entities;
using MedTrackDash.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MedTrackDash.Services
{
	/// <summary>
	/// Service responsible for interacting with appointments in the database.
	/// </summary>
	public class AppointmentDatabaseService : IAppointmentDatabaseService
	{
		private readonly MedTrackContext _context;
		private readonly ILogger<AppointmentDatabaseService> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentDatabaseService"/> class.
		/// </summary>
		/// <param name="context">The database context.</param>
		/// <param name="logger">The logger.</param>
		public AppointmentDatabaseService(MedTrackContext context, ILogger<AppointmentDatabaseService> logger)
		{
			_context = context;
			_logger = logger;

			if (!_context.Patients.Any() || !_context.Doctors.Any())
			{
				SeedData.Seed(context);
			}
		}

		/// <summary>
		/// Adds a new appointment to the database.
		/// </summary>
		/// <param name="appointmentDto">The appointment data.</param>
		public async Task AddAppointment(AppointmentDto appointmentDto)
		{
			var appointmentEntity = new AppointmentEntity()
			{
				DateTime = appointmentDto.DateTime,
				PatientId = appointmentDto.PatientId,
				DoctorId = appointmentDto.DoctorId
			};

			_context.Appointments.Add(appointmentEntity);
			await _context.SaveChangesAsync();
			_logger.LogInformation("Appointment added to the database.");
		}

		/// <summary>
		/// Retrieves an appointment by its ID.
		/// </summary>
		/// <param name="id">The ID of the appointment.</param>
		/// <returns>The appointment with the specified ID, or null if not found.</returns>
		public async Task<AppointmentDto> GetAppointmentById(int id)
		{
			var appointmentEntity = await _context.Appointments
				.Where(a => a.Id == id)
				.FirstOrDefaultAsync();

			if (appointmentEntity != null)
			{
				return appointmentEntity.ToDto();
			}

			_logger.LogInformation("Appointment not found in the database.");
			return null;
		}

		/// <summary>
		/// Retrieves all appointments from the database.
		/// </summary>
		/// <returns>A list of all appointments.</returns>
		public async Task<List<AppointmentDto>> GetAllAppointments()
		{
			var appointments = await _context.Appointments
				.Select(a => a.ToDto())
				.ToListAsync();
			_logger.LogInformation("Retrieved all appointments from the database.");
			return appointments;
		}

		/// <summary>
		/// Updates an existing appointment in the database.
		/// </summary>
		/// <param name="id">The ID of the appointment to update.</param>
		/// <param name="appointmentDto">The updated appointment data.</param>
		/// <returns>True if the appointment was updated successfully, otherwise false.</returns>
		public async Task<bool> UpdateAppointment(int id, AppointmentDto appointmentDto)
		{
			var appointmentEntity = await _context.Appointments
				.Where(a => a.Id == id)
				.FirstOrDefaultAsync();

			if (appointmentEntity != null)
			{
				appointmentEntity.DateTime = appointmentDto.DateTime;
				appointmentEntity.PatientId = appointmentDto.PatientId;
				appointmentEntity.DoctorId = appointmentDto.DoctorId;

				await _context.SaveChangesAsync();
				_logger.LogInformation("Appointment information updated in the database.");
				return true;
			}

			_logger.LogInformation("Appointment not found in the database.");
			return false;
		}

		/// <summary>
		/// Deletes an appointment from the database.
		/// </summary>
		/// <param name="id">The ID of the appointment to delete.</param>
		/// <returns>True if the appointment was deleted successfully, otherwise false.</returns>
		public async Task<bool> DeleteAppointment(int id)
		{
			var appointmentEntity = await _context.Appointments.FindAsync(id);
			if (appointmentEntity != null)
			{
				_context.Appointments.Remove(appointmentEntity);
				await _context.SaveChangesAsync();
				_logger.LogInformation("Appointment deleted from the database.");
				return true;
			}

			_logger.LogInformation("Appointment not found in the database.");
			return false;
		}
	}

}
