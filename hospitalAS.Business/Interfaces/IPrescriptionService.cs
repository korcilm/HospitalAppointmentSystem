using hospitalAS.Dto.PrescriptionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IPrescriptionService
    {
        Task AddPresscription(AddPrescriptionDto model);
        Task<IList<ListPrescriptionDto>> GetAllPrescriptionByAppointmentId(int id);
        Task DeletePrescription(int id);
    }
}
