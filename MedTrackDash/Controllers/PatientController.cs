using MedTrackDash.Dtos;
using MedTrackDash.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedTrackDash.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PatientController : Controller
	{
		private readonly IPatientDatabaseService _patientDatabaseService;

		public PatientController(IPatientDatabaseService patientDatabaseService)
		{
			_patientDatabaseService = patientDatabaseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var patients = await _patientDatabaseService.GetAllPatients();

			return Ok(patients);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var patient = await _patientDatabaseService.GetPatientById(id);

			if (patient != null)
			{
				return Ok(patient);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, PatientUpdateDto patientUpdateDto)
		{
			var success = await _patientDatabaseService.UpdatePatient(id, patientUpdateDto);
			return Ok(success);
		}

		[HttpPut]
		public async Task<IActionResult> Add(PatientAddDto patientAddDto)
		{
			await _patientDatabaseService.AddPatient(patientAddDto);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteById(int id)
		{
			if (await _patientDatabaseService.DeletePatient(id))
			{
				return Ok();
			}

			return NotFound();
		}
	}
}
