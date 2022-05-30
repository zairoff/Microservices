using System;

namespace Stoma.Contracts
{
    public record DoctorCreated(Guid Id, string Name, string Phone);
    public record PatientCreated(Guid Id, string Name, string Phone, string Address);
}