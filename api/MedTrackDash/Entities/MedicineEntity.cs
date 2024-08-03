namespace MedTrackDash.Entities
{
	public class MedicineEntity
	{
		/// <summary>
		/// Gets or sets the ID of the medicine.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the medicine.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the medicine.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the route of administration of the medicine (e.g., oral, topical, injection).
		/// </summary>
		public string Route { get; set; }

		/// <summary>
		/// Gets or sets the prescription foreign key
		/// </summary>
		public int PrescriptionId { get; set; }

		/// <summary>
		/// Gets or sets the prescription associated with the medicine.
		/// </summary>
		public PrescriptionEntity Prescription { get; set; }
	}
}

