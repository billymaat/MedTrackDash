﻿using MedTrackDash.Dtos;

namespace MedTrackDash.Services;

public interface IAppointmentDatabaseService
{
	/// <summary>
	/// Adds a new appointment to the database.
	/// </summary>
	/// <param name="appointmentAddDto">The appointment data.</param>
	Task AddAppointment(AppointmentAddDto appointmentAddDto);

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

	/// <summary>
	/// Retrieves appointments for a specific date from the database.
	/// </summary>
	/// <param name="date">The date for which appointments should be retrieved.</param>
	/// <returns>A list of AppointmentDto objects representing the appointments for the specified date.</returns>
	Task<List<AppointmentDto>> GetAppointmentByDate(DateOnly date);
}