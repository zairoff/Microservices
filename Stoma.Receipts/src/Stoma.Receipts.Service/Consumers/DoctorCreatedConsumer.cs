using System.Threading.Tasks;
using MassTransit;
using Stoma.Common;
using Stoma.Contracts;
using Stoma.Receipts.Service.Entities;

namespace Stoma.Receipts.Service.Consumers
{
    public class DoctorCreatedConsumer : IConsumer<DoctorCreated>
    {
        private readonly IRepository<Doctor> _repository;

        public DoctorCreatedConsumer(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<DoctorCreated> context)
        {
            var message = context.Message;

            var doctor = await _repository.GetAsync(message.Id);

            if (doctor != null) return;

            doctor = new Doctor
            {
                Id = message.Id,
                Name = message.Name,
                Phone = message.Phone
            };

            await _repository.CreateAsync(doctor);
        }
    }
}