using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrete
{
    public class Role:Entity
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public IList<JobRoles> JobRoles  { get; set; }
    }
}
