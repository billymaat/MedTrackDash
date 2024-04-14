using MedTrackDash.Dtos;
using MedTrackDash.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedTrackDash.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorDatabaseService _doctorDatabaseService;

		public DoctorController(IDoctorDatabaseService doctorDatabaseService)
		{
			_doctorDatabaseService = doctorDatabaseService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<DoctorDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAll()
		{
			var doctors = await _doctorDatabaseService.GetAllDoctors();
			return Ok(doctors);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
		{
			var doctor = await _doctorDatabaseService.GetDoctorById(id);
			if (doctor != null)
			{
				return Ok(doctor);
			}
			return NotFound();
		}

		[HttpGet("getids")]
		[ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByIds([FromQuery] List<int> ids)
		{
			var doctors = await _doctorDatabaseService.GetDoctorsByIds(ids);

			if (doctors != null)
			{
				return Ok(doctors);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, DoctorUpdateDto doctorUpdateDto)
		{
			var success = await _doctorDatabaseService.UpdateDoctor(id, doctorUpdateDto);
			if (success)
			{
				return Ok();
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Add(DoctorAddDto doctorDto)
		{
			await _doctorDatabaseService.AddDoctor(doctorDto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteById(int id)
		{
			var success = await _doctorDatabaseService.DeleteDoctor(id);
			if (success)
			{
				return Ok();
			}
			return NotFound();
		}

		[HttpGet("patients/{id}")]
		public async Task<IActionResult> GetPatients(int id)
		{
			var patients = await _doctorDatabaseService.GetDoctorPatientsById(id);
			return Ok(patients);
		}

		[HttpGet("{id}/appointments")]
		public async Task<IActionResult> GetAppointments(int id)
		{
			var appointments = await _doctorDatabaseService.GetDoctorAppointments(id);

			if (appointments == null)
			{
				return NotFound();
			}

			return Ok(appointments);
		}
	}

}
