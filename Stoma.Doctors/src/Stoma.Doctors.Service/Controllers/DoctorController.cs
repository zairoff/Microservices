using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stoma.Doctors.Service.Entities;
using System.Linq;
using System;
using Stoma.Doctors.Service.Dtos;
using Stoma.Common;
using MassTransit;
using Stoma.Contracts;

namespace Stoma.Doctors.Service.Controllers
{
    [ApiController]
    [Route("doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IPublishEndpoint _publishEndPoint;

        public DoctorController(IRepository<Doctor> doctorRepository, IPublishEndpoint publishEndPoint)
        {
            _doctorRepository = doctorRepository;
            _publishEndPoint = publishEndPoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = (await _doctorRepository.GetAllAsync()).Select(d => d.AsDto());

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var doctors = (await _doctorRepository.GetAsync(id)).AsDto();

            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DoctorCreateDto doctorCreateDto)
        {
            var doctor = new Doctor
            {
                Name = doctorCreateDto.Name,
                Birthday = doctorCreateDto.Birthday,
                Phone = doctorCreateDto.Phone
            };

            await _doctorRepository.CreateAsync(doctor);

            await _publishEndPoint.Publish(new DoctorCreated(doctor.Id, doctor.Name, doctor.Phone));

            return CreatedAtAction(nameof(GetAsync), new { id = doctor.Id }, doctor);
        }
    }
}