using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.PrescriptionDtos
{
    public class ListPrescriptionDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Medicament { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public string Usage { get; set; }
        public int UsingCount { get; set; }
        public int MedicamentCount { get; set; }
    }
}
