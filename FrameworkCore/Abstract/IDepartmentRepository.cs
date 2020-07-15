using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Abstract
{
    public interface IDepartmentRepository:IRepository<Department>
    {
          Task<List<Department>> GetAllDepartmentWithChild();
       
    }
}
