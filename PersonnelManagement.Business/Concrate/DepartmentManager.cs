using FrameworkCore.Abstract;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Concrate
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

        public async Task<Department> AddAsync(Department department)
        {
              await _unitOfWork.Department.AddAsync(department);
             await _unitOfWork.CommitAsync();
            return department;
        }

        public void Delete(Department department)
        {
            _unitOfWork.Department.Delete(department);
            _unitOfWork.Commit();
        }

        public void Delete(object EntityId)
        {
            _unitOfWork.Department.Delete(EntityId);
            _unitOfWork.Commit();
        }

        public IEnumerable<Department> GetAll(Expression<Func<Department, bool>> filter = null)
        {
            return _unitOfWork.Department.GetAll(filter);
        }

        public async Task<List<Department>> GetAllDepartmentWithChild()
        {
            return await _departmentRepository.GetAllDepartmentWithChild();
        }

        public async Task<Department> GetAsync(Expression<Func<Department, bool>> filter)
        {
            return await _unitOfWork.Department.GetAsync(filter);
        }

        public async Task<Department> GetByIdAsync(int Id)
        {
           return await _unitOfWork.Department.GetByIdAsync(Id);
        }

        public void Update(Department department)
        {
            _unitOfWork.Department.Update(department);
        }
    }
}
