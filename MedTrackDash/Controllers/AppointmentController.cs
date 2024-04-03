using MedTrackDash.Dtos;
using MedTrackDash.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedTrackDash.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentDatabaseService _appointmentDatabaseService;

		public AppointmentController(IAppointmentDatabaseService appointmentDatabaseService)
		{
			_appointmentDatabaseService = appointmentDatabaseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAppointments()
		{
			var appointments = await _appointmentDatabaseService.GetAllAppointments();
			return Ok(appointments);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppointmentById(int id)
		{
			var appointment = await _appointmentDatabaseService.GetAppointmentById(id);

			if (appointment != null)
			{
				return Ok(appointment);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAppointment(int id, AppointmentDto appointmentDto)
		{
			var success = await _appointmentDatabaseService.UpdateAppointment(id, appointmentDto);

			if (success)
			{
				return Ok();
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddAppointment(AppointmentDto appointmentDto)
		{
			await _appointmentDatabaseService.AddAppointment(appointmentDto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAppointment(int id)
		{
			var success = await _appointmentDatabaseService.DeleteAppointment(id);

			if (success)
			{
				return Ok();
			}

			return NotFound();
		}
	}

}
