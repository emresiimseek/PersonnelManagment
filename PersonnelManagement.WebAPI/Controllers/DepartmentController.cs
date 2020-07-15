using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Utilities.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.Business.ValidationRules.FluentValidation;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.EntityFramework.Concrate.DTOs;


namespace PersonnelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        private IAutoMapperBase _autoMapperBase;
        public DepartmentController(IDepartmentService departmentService, IAutoMapperBase autoMapperBase)
        {
            _autoMapperBase = autoMapperBase;
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> departments = await _departmentService.GetAllDepartmentWithChild();
            return Ok(_autoMapperBase.MapToSameList<Department, DepartmentDto>(departments));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Department department = await _departmentService.GetByIdAsync(id);
            return Ok(_autoMapperBase.MapToSameType<Department, DepartmentDto>(department));
        }
        [HttpPost]
        public async Task<IActionResult> Save(DepartmentDto departmentDto)
        {
            var newDepartment = await _departmentService.AddAsync(_autoMapperBase.MapToSameType<DepartmentDto, Department>(departmentDto));
            return Created(string.Empty, _autoMapperBase.MapToSameType<Department, DepartmentDto>(newDepartment));
        }
    }
}
