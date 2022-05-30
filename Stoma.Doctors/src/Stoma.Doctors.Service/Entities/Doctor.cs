using System;
using Stoma.Common;

namespace Stoma.Doctors.Service.Entities
{
    public class Doctor : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }
    }
}