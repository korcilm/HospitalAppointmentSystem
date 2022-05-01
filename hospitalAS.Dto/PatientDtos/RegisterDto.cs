using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.PatientDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Kan grubu alanı boş geçilmez")]
        public int? BloodTypeId { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilmez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilmez")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kimlik numarası alanı boş geçilmez")]
        [MaxLength(11, ErrorMessage = "Maksimum 11 karakter girmelisiniz")]
        public string IdentityNumber { get; set; }
        [MinLength(3, ErrorMessage = "Minimum 3 karakter girmelisiniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı boş geçilmez")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Doğum günü alanı boş geçilmez")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Adres alanı boş geçilmez")]
        public string Address { get; set; }
    }
}
