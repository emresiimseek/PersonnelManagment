using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrete
{
    public class JobRoles:Entity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
