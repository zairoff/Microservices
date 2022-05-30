using System;

namespace Stoma.Receipts.Service.Entities
{
    public record ReceiptDto(Guid Id, Doctor Doctor, Patient Patient, DateTime VisitDate);
    public record ReceiptCreateDto(Guid DoctorId, Guid PatientId, DateTime VisitDate);
}