using MVC_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Lab2.ViewModals
{
    public class EmployeeViewModal
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public List<Department> Departments { get; set; }
    }
}