using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Abstract
{
   public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        Task CommitAsync();
        void Commit();
    }
}
