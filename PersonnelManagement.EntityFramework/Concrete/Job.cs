using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrete
{
    public class Job:Entity
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public  ICollection<Personnel> Personnels { get; set; }
        public IList<JobRoles> JobRoles { get; set; }
    }
}
