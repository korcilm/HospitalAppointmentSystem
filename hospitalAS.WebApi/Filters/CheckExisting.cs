using hospitalAS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Filters
{
    public class CheckExisting:IAsyncActionFilter
    {
        private readonly IUserService _userService;
        public CheckExisting(IUserService userService)
        {
            _userService = userService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idExist = context.ActionArguments.ContainsKey("id");
            if (!idExist)
            {
                context.Result = new BadRequestObjectResult(new { message = $"id parametresi yok" });
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (await _userService.IsExists(id))
                {
                    await next.Invoke();
                }
                context.Result= new BadRequestObjectResult(new { message = $"({id}) Bu  id ye ait kullanıcı bulunamadı" });
            }
        }
    }
}
