using hospitalAS.Business.Interfaces;
using hospitalAS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Filters
{
    public class ValidId<TEntity> : IAsyncActionFilter where TEntity : class, IEntity, new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
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
                var checkedId = (int)context.ActionArguments["id"];
                var entity = _genericService.IsExists(checkedId).Result;

                if (entity == true)
                {
                   await next.Invoke();
                }
                context.Result = new BadRequestObjectResult(new { message = $"({checkedId}) Bu  id ye ait satır bulunamadı" });
            }

        }
    }
}
