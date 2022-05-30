using Stoma.Patients.Service.Dtos;

namespace Stoma.Patients.Service.Entities
{
    public static class Extensionss
    {
        public static PatientDto AsDto(this Patient patient)
        {
            return new PatientDto(patient.Id, patient.Name, patient.Phone, patient.Address, patient.Birthday);
        }
    }
}