using MedTrackDash.Dtos;
using MedTrackDash.Entities;

namespace MedTrackDash.Extensions
{
    public static class AppointmentMapper
    {
	    /// <summary>
	    /// Maps an AppointmentEntity to an AppointmentDto.
	    /// </summary>
	    /// <param name="appointmentEntity">The AppointmentEntity to map.</param>
	    /// <returns>The mapped AppointmentDto.</returns>
	    public static AppointmentDto ToDto(this AppointmentEntity appointmentEntity)
	    {
		    return new AppointmentDto
		    {
			    Id = appointmentEntity.Id,
			    DateTime = appointmentEntity.DateTime,
			    PatientId = appointmentEntity.PatientId,
			    DoctorId = appointmentEntity.DoctorId
		    };
	    }
	}
}
