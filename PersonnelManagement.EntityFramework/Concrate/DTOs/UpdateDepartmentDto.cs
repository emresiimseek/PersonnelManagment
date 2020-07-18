using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrate.DTOs
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
