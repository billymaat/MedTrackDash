using MedTrackDash.Dtos;

namespace MedTrackDash.Services;

public interface IAppointmentDatabaseService
{
	/// <summary>
	/// Adds a new appointment to the database.
	/// </summary>
	/// <param name="appointmentDto">The appointment data.</param>
	Task AddAppointment(AppointmentDto appointmentDto);

	/// <summary>
	/// Retrieves an appointment by its ID.
	/// </summary>
	/// <param name="id">The ID of the appointment.</param>
	/// <returns>The appointment with the specified ID, or null if not found.</returns>
	Task<AppointmentDto> GetAppointmentById(int id);

	/// <summary>
	/// Retrieves all appointments from the database.
	/// </summary>
	/// <returns>A list of all appointments.</returns>
	Task<List<AppointmentDto>> GetAllAppointments();

	/// <summary>
	/// Updates an existing appointment in the database.
	/// </summary>
	/// <param name="id">The ID of the appointment to update.</param>
	/// <param name="appointmentDto">The updated appointment data.</param>
	/// <returns>True if the appointment was updated successfully, otherwise false.</returns>
	Task<bool> UpdateAppointment(int id, AppointmentDto appointmentDto);

	/// <summary>
	/// Deletes an appointment from the database.
	/// </summary>
	/// <param name="id">The ID of the appointment to delete.</param>
	/// <returns>True if the appointment was deleted successfully, otherwise false.</returns>
	Task<bool> DeleteAppointment(int id);
}