using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Filters
{
    public class IsExistsAttribute:TypeFilterAttribute
    {
        public IsExistsAttribute():base(typeof(CheckExisting))
        {

        }
    }
}
