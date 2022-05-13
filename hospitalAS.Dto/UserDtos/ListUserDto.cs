using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Dto.RoleDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.UserDtos
{
    public class ListUserDto
    {
        public int Id { get; set; }
        public int? BloodTypeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public RoleListDto Role { get; set; }
        public BloodTypeDropdownListDto BloodType { get; set; }
    }
}
