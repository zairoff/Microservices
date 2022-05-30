using System;
using Stoma.Common;

namespace Stoma.Receipts.Service.Entities
{
    public class Receipt : IEntity
    {
        public Guid Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime VisitDate { get; set; }
    }
}