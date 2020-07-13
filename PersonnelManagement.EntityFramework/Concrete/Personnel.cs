using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrete
{
    public class Personnel : Entity
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfRecuitment { get; set; }
        public DateTime EmploymentendDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Job Job { get; set; } 
        public int JobId { get; set; }
 


    }
}
