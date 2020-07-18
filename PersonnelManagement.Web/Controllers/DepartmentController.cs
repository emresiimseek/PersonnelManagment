using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using PersonnelManagement.Web.ApiService;

namespace PersonnelManagement.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentApiService _departmentApiService;
        public DepartmentController(DepartmentApiService departmentApiService)
        {
            _departmentApiService = departmentApiService;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<DepartmentDto> departmentDtos = await _departmentApiService.GetAllAsync();
            List<DepartmentDto> departments = departmentDtos.ToList();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {
            await _departmentApiService.AddAsync(departmentDto);
            return RedirectToAction("Index", "Department");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            UpdateDepartmentDto updateDepartmentDto = await _departmentApiService.GetByIdUpdateDtoAsync(Id);
            return View(updateDepartmentDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentApiService.Update(updateDepartmentDto);
            return View((updateDepartmentDto));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            DepartmentDto departmentDto = await _departmentApiService.GetByIdAsync(Id);
            return View(departmentDto);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentDto departmentDto)
        {
            await _departmentApiService.Delete(departmentDto.DepartmentId);
            return RedirectToAction("Index", "Department");
        }
    }
}
