using hospitalAS.Dto.PrescriptionDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IPrescriptionService : IGenericService<Prescription>
    {
        Task AddPresscription(AddPrescriptionDto model);
        Task<IList<ListPrescriptionDto>> GetAllPrescriptionByAppointmentId(int id);
        Task DeletePrescription(int id);
    }
}
