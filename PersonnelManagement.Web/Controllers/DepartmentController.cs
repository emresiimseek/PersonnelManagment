using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Utilities.Mappings;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.EntityFramework.Concrate.DTOs;

namespace PersonnelManagement.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        private IAutoMapperBase _autoMapperBase;
        public DepartmentController(IDepartmentService departmentService, IAutoMapperBase autoMapperBase)
        {
            _autoMapperBase = autoMapperBase;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            List<Department> departments= _departmentService.GetAll().ToList();
            return View(_autoMapperBase.MapToSameList<Department,DepartmentDto>(departments));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {
            await _departmentService.AddAsync(_autoMapperBase.MapToSameType<DepartmentDto, Department>(departmentDto));
            return View(departmentDto);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Department department= await _departmentService.GetByIdAsync(Id);
            return View(_autoMapperBase.MapToSameType<Department, DepartmentDto>(department));
        }
        [HttpPost]
        public IActionResult Edit(DepartmentDto departmentDto)
        {
            _departmentService.Update(_autoMapperBase.MapToSameType<DepartmentDto,Department>(departmentDto));
            return View((departmentDto));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Department department =await _departmentService.GetByIdAsync(Id);
            return View(_autoMapperBase.MapToSameType<Department, DepartmentDto>(department));

        }
        [HttpPost]
        public IActionResult Delete(DepartmentDto departmentDto)
        {
            _departmentService.Delete(_autoMapperBase.MapToSameType<DepartmentDto, Department>(departmentDto));
            return RedirectToAction("Index","Department");
        }
    }
}
