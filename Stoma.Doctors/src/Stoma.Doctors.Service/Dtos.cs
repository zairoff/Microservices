using System;

namespace Stoma.Doctors.Service.Dtos
{
    public record DoctorDto(Guid Id, string Name, string Phone, DateTime Birthday);

    public record DoctorCreateDto(string Name, string Phone, DateTime Birthday);
}