using System;
using Stoma.Common;

namespace Stoma.Receipts.Service.Entities
{
    public class Doctor : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}