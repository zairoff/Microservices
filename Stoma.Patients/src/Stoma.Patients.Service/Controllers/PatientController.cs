using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Stoma.Common;
using Stoma.Contracts;
using Stoma.Patients.Service.Dtos;
using Stoma.Patients.Service.Entities;

namespace Stoma.Patients.Service.Controllers
{
    [ApiController]
    [Route("patients")]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<Patient> _repository;
        private readonly IPublishEndpoint _publishEndPoint;

        public PatientController(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = (await _repository.GetAllAsync()).Select(patient => patient.AsDto());

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var patient = (await _repository.GetAsync(id)).AsDto();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PatientCreateDto patientCreateDto)
        {
            var patient = new Patient
            {
                Name = patientCreateDto.Name,
                Birthday = patientCreateDto.Birthday,
                Phone = patientCreateDto.Phone,
                Address = patientCreateDto.Address
            };

            await _repository.CreateAsync(patient);

            await _publishEndPoint.Publish(new PatientCreated(patient.Id, patient.Name, patient.Phone, patient.Address));

            return CreatedAtAction(nameof(GetAsync), new { id = patient.Id }, patient);
        }
    }
}