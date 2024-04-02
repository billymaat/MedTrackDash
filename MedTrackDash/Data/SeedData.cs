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
			medTrackContext.Patients.AddRange(
				new List<PatientEntity>()
				{
				new PatientEntity() { FirstName = "John", Surname = "Smith", Age = 35, Gender = "Male" },
				new PatientEntity() { FirstName = "Jane", Surname = "Doe", Age = 28, Gender = "Female" },
				new PatientEntity() { FirstName = "Michael", Surname = "Johnson", Age = 42, Gender = "Male" },
				new PatientEntity() { FirstName = "Emily", Surname = "Brown", Age = 29, Gender = "Female" },
				new PatientEntity() { FirstName = "William", Surname = "Jones", Age = 50, Gender = "Male" },
				new PatientEntity() { FirstName = "Sophia", Surname = "Williams", Age = 65, Gender = "Female" },
				new PatientEntity() { FirstName = "Daniel", Surname = "Miller", Age = 38, Gender = "Male" },
				new PatientEntity() { FirstName = "Olivia", Surname = "Wilson", Age = 22, Gender = "Female" },
				new PatientEntity() { FirstName = "James", Surname = "Taylor", Age = 45, Gender = "Male" },
				new PatientEntity() { FirstName = "Emma", Surname = "Anderson", Age = 31, Gender = "Female" },
				new PatientEntity() { FirstName = "Alexander", Surname = "Thomas", Age = 55, Gender = "Male" },
				new PatientEntity() { FirstName = "Isabella", Surname = "Jackson", Age = 33, Gender = "Female" },
				new PatientEntity() { FirstName = "Benjamin", Surname = "White", Age = 40, Gender = "Male" },
				new PatientEntity() { FirstName = "Mia", Surname = "Harris", Age = 27, Gender = "Female" },
				new PatientEntity() { FirstName = "Jacob", Surname = "Martinez", Age = 48, Gender = "Male" },
				new PatientEntity() { FirstName = "Ava", Surname = "Lee", Age = 36, Gender = "Female" },
				new PatientEntity() { FirstName = "Ethan", Surname = "Lopez", Age = 30, Gender = "Male" },
				new PatientEntity() { FirstName = "Charlotte", Surname = "Garcia", Age = 25, Gender = "Female" },
				new PatientEntity() { FirstName = "Michael", Surname = "Rodriguez", Age = 44, Gender = "Male" },
				new PatientEntity() { FirstName = "Amelia", Surname = "Perez", Age = 39, Gender = "Female" }
				}
			);

			medTrackContext.SaveChanges();
		}
	}
}
