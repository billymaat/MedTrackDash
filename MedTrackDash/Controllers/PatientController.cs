using MedTrackDash.Dtos;
using MedTrackDash.Extensions;
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

			return Ok(patients.Select(p => p.ToDto()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var patient = await _databaseService.GetPatientById(id);

			if (patient != null)
			{
				return Ok(patient.ToDto());
			}

			return NotFound();
		}
	}


}
