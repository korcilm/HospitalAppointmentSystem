using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Poliklinik Seçiniz")]
        public int PoliclinicId { get; set; }
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilmez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilmez")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kimlik numarası alanı boş geçilmez")]
        [MaxLength(11, ErrorMessage = "Maksimum 11 karakter girmelisiniz")]
        public string IdentityNumber { get; set; }
        [MinLength(8, ErrorMessage = "Minimum 8 karakter girmelisiniz")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Policlinic Policlinic { get; set; }
        public Role Role { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
