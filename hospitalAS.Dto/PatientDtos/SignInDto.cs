using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.PatientDtos
{
    public class SignInDto
    {
        [MaxLength(11, ErrorMessage = "Maksimum 11 karakter girmelisiniz")]
        public string IdentityNumber { get; set; }
        [MinLength(8, ErrorMessage = "Minimum 8 karakter girmelisiniz")]
        public string Password { get; set; }
    }
}
