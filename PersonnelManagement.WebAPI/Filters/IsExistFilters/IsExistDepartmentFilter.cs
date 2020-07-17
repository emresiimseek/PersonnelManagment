using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Abstract;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManagement.WebAPI.Filters
{
    public class IsExistDepartmentFilter:ActionFilterAttribute
    {
        public IDepartmentService _service { get; set; }
        public IsExistDepartmentFilter(IDepartmentService service)
        {
            _service = service;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
                
             var res =await _service.GetByIdAsync(id);
            ErrorDto errorDto = new ErrorDto();
            if (res != null)
            {
                await next();
            }
            else
            {
                errorDto.Status = 404;
                errorDto.Errors.Add($"{id} id'li departman veritabınında bulunamadı.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
