using FrameworkCore.Abstract;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Concrete
{
    public class DepartmentManager: IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        private IUnitOfWork _unitOfWork;

        public DepartmentManager(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Department department)
        {
             await _unitOfWork.department.AddAsync(department);
            await _unitOfWork.CommitAsync();
        }
    }
}
