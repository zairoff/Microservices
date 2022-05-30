using System;
using Stoma.Common;

namespace Stoma.Patients.Service.Entities
{
    public class Patient : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }
    }
}