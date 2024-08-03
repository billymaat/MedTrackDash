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
		[ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAll()
		{
			var patients = await _patientDatabaseService.GetAllPatients();

			return Ok(patients);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
		{
			var patient = await _patientDatabaseService.GetPatientById(id);

			if (patient != null)
			{
				return Ok(patient);
			}

			return NotFound();
		}

		[HttpGet("getids")]
		[ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByIds([FromQuery] List<int> ids)
		{
			var patients = await _patientDatabaseService.GetPatientsByIds(ids);

			if (patients != null)
			{
				return Ok(patients);
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

		[HttpGet("{id}/prescriptions")]
		public async Task<IActionResult> GetPrescriptions(int id)
		{
			var prescriptions = await _patientDatabaseService.GetPatientPrescriptions(id);

			if (prescriptions != null)
			{
				return Ok(prescriptions);
			}

			return NotFound();
		}

		[HttpPut("{id}/addprescription")]
		public async Task<IActionResult> AddPrescription(int id, PrescriptionAddDto prescriptionAddDto)
		{
			await _patientDatabaseService.AddPrescription(id, prescriptionAddDto);
			return Ok();
		}


		[HttpGet("{id}/appointments")]
		public async Task<IActionResult> GetPatientAppointments(int id)
		{
			var appointments = await _patientDatabaseService.GetPatientAppointments(id);
			if (appointments != null)
			{
				return Ok(appointments);
			}

			return NotFound();
		}
	}
}
