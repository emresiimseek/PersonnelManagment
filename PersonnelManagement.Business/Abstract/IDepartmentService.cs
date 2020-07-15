using FrameworkCore.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Abstract
{
    public interface IDepartmentService:IService<Department>
    {
        Task<List<Department>> GetAllDepartmentWithChild();
    }
}
