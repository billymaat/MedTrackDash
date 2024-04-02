using MedTrackDash.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedTrackDash.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PatientController : Controller
	{
		private readonly IDatabaseService _databaseService;

		public PatientController(IDatabaseService databaseService)
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

		[HttpPut]
		public async Task<IActionResult> Add(PatientAddDto patientAddDto)
		{
			await _databaseService.AddPatient(patientAddDto);
			return Ok();
		}
	}


}
