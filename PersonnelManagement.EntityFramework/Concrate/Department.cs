﻿using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrate
{
    public class Department:Entity
    {
        public int DepartmentId { get; set; }
        public string Name  { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
  


    }
}
