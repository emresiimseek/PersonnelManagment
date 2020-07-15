using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PersonnelManagement.EntityFramework.Concrete.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Personnel> Personnels { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
