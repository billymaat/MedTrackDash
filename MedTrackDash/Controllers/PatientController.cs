using MedTrackDash.Dtos;
using MedTrackDash.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedTrackDash.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PatientController : Controller
	{
		private readonly IPatientDatabaseService _databaseService;

		public PatientController(IPatientDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var patients = await _databaseService.GetAllPatients();

			return Ok(patients);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var patient = await _databaseService.GetPatientById(id);

			if (patient != null)
			{
				return Ok(patient);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, PatientUpdateDto patientUpdateDto)
		{
			var success = await _databaseService.UpdatePatient(id, patientUpdateDto);
			return Ok(success);
		}

		[HttpPut]
		public async Task<IActionResult> Add(PatientAddDto patientAddDto)
		{
			await _databaseService.AddPatient(patientAddDto);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteById(int id)
		{
			if (await _databaseService.DeletePatient(id))
			{
				return Ok();
			}

			return NotFound();
		}
	}


}
