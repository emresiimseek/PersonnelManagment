﻿using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.EntityFramework.Concrate
{
    public class Personnel : Entity
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfRecuitment { get; set; }
        public DateTime EmploymentendDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Job Job { get; set; } 
        public int JobId { get; set; }
 


    }
}
