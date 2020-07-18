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
using PersonnelManagement.WebAPI.Filters;
using PersonnelManagement.WebAPI.Filters.FluentValidation;

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
        [HttpGet("personnels")]
        public async Task<IActionResult> GetAllDepartmentWithChild()
        {
            List<Department> departments = await _departmentService.GetAllDepartmentWithChild();
            return Ok(_autoMapperBase.MapToSameList<Department, DepartmentWithPersonnelDto>(departments));
        }
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Department> departments =  _departmentService.GetAll().ToList();
            return Ok(_autoMapperBase.MapToSameList<Department, DepartmentDto>(departments));
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(IsExistDepartmentFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            Department department = await _departmentService.GetByIdAsync(id);
            return Ok(_autoMapperBase.MapToSameType<Department, DepartmentDto>(department));
        }
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Save(DepartmentDto departmentDto)
        {
            var newDepartment = await _departmentService.AddAsync(_autoMapperBase.MapToSameType<DepartmentDto, Department>(departmentDto));
            return Created(string.Empty, _autoMapperBase.MapToSameType<Department, DepartmentDto>(newDepartment));
        }
        [HttpPut]
        [ValidationFilter]
        public IActionResult Update(UpdateDepartmentDto updateDepartmentDto)
        {
            Department department = _autoMapperBase.MapToSameType<UpdateDepartmentDto, Department>(updateDepartmentDto);
            _departmentService.Update(department);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IsExistDepartmentFilter))]
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return NoContent();
        }

    }
}
