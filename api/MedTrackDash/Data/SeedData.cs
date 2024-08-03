using MedTrackDash.Entities;

namespace MedTrackDash.Data
{
	public static class SeedData
	{
		/// <summary>
		/// Seeds the MedTrackContext with initial patient data.
		/// </summary>
		/// <param name="medTrackContext">The MedTrackContext to seed.</param>
		public static void Seed(MedTrackContext medTrackContext)
		{
			var patients = new List<PatientEntity>()
			{
				new PatientEntity() { FirstName = "John", Surname = "Smith", Age = 35, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Jane", Surname = "Doe", Age = 28, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Michael", Surname = "Johnson", Age = 42, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Emily", Surname = "Brown", Age = 29, Gender = Gender.Female },
				new PatientEntity() { FirstName = "William", Surname = "Jones", Age = 50, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Sophia", Surname = "Williams", Age = 65, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Daniel", Surname = "Miller", Age = 38, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Olivia", Surname = "Wilson", Age = 22, Gender = Gender.Female },
				new PatientEntity() { FirstName = "James", Surname = "Taylor", Age = 45, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Emma", Surname = "Anderson", Age = 31, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Alexander", Surname = "Thomas", Age = 55, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Isabella", Surname = "Jackson", Age = 33, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Benjamin", Surname = "White", Age = 40, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Mia", Surname = "Harris", Age = 27, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Jacob", Surname = "Martinez", Age = 48, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Ava", Surname = "Lee", Age = 36, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Ethan", Surname = "Lopez", Age = 30, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Charlotte", Surname = "Garcia", Age = 25, Gender = Gender.Female },
				new PatientEntity() { FirstName = "Michael", Surname = "Rodriguez", Age = 44, Gender = Gender.Male },
				new PatientEntity() { FirstName = "Amelia", Surname = "Perez", Age = 39, Gender = Gender.Female }
			};

			var doctors = new List<DoctorEntity>()
			{
				new DoctorEntity() { FirstName = "David", LastName = "Smith", Specialty = "Cardiology" },
				new DoctorEntity() { FirstName = "Sarah", LastName = "Johnson", Specialty = "Dermatology" },
				new DoctorEntity() { FirstName = "Michael", LastName = "Brown", Specialty = "Pediatrics" },
				new DoctorEntity() { FirstName = "Emily", LastName = "Taylor", Specialty = "Neurology" },
				new DoctorEntity() { FirstName = "William", LastName = "Jones", Specialty = "Oncology" },
				new DoctorEntity() { FirstName = "Sophia", LastName = "Miller", Specialty = "Orthopedics" },
				new DoctorEntity() { FirstName = "Daniel", LastName = "Wilson", Specialty = "Psychiatry" },
				new DoctorEntity() { FirstName = "Olivia", LastName = "Anderson", Specialty = "Radiology" },
				new DoctorEntity() { FirstName = "James", LastName = "Harris", Specialty = "Urology" },
				new DoctorEntity() { FirstName = "Emma", LastName = "Martinez", Specialty = "Gastroenterology" }
			};

			foreach (var patient in patients)
			{
				int doctorIndex = new Random().Next(0, doctors.Count);
				var doctor = doctors[doctorIndex];
				patient.Doctor = doctor;
			}

			medTrackContext.Patients.AddRange(patients);
			medTrackContext.Doctors.AddRange(doctors);

			medTrackContext.SaveChanges();
		}
	}
}
