using Stoma.Doctors.Service.Dtos;

namespace Stoma.Doctors.Service.Entities
{
    public static class Extensions
    {
        public static DoctorDto AsDto(this Doctor doctor)
        {
            return new DoctorDto(doctor.Id, doctor.Name, doctor.Phone, doctor.Birthday);
        }
    }
}