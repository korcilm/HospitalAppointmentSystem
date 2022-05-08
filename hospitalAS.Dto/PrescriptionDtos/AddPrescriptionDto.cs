using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.PrescriptionDtos
{
    public class AddPrescriptionDto
    {
        public int AppointmentId { get; set; }
        [Required(ErrorMessage ="İlaç adı boş geçilemez")]
        public string Medicament { get; set; }
        [Required(ErrorMessage = "İlaç açıklaması boş geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Periyot boş geçilemez")]
        public string Period { get; set; }
        [Required(ErrorMessage = "Kullanım şekli boş geçilemez")]
        public string Usage { get; set; }
        [Required(ErrorMessage = "Kullanım Adeti boş geçilemez")]
        public int UsingCount { get; set; }
        [Required(ErrorMessage = "İlaç kutu adeti boş geçilemez")]
        public int MedicamentCount { get; set; }
    }
}
