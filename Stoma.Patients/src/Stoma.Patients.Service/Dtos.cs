using System;

namespace Stoma.Patients.Service.Dtos
{
    public record PatientDto(Guid Id, string Name, string Phone, string Address, DateTime Birthday);
    public record PatientCreateDto(string Name, string Phone, string Address, DateTime Birthday);
}