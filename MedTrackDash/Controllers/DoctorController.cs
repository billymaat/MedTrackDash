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
		public async Task<IActionResult> GetAll()
		{
			var doctors = await _doctorDatabaseService.GetAllDoctors();
			return Ok(doctors);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var doctor = await _doctorDatabaseService.GetDoctorById(id);
			if (doctor != null)
			{
				return Ok(doctor);
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
	}

}
