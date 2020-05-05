using MVC_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lab2.Controllers
{
    public class AddEmployeeController : Controller
    {
        // GET: AddEmployee
        [HttpGet]
        public ViewResult EmployeeForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult EmployeeForm(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee(employee.Name, employee.Gender, employee.Email, employee.Address, employee.Salary);
                ModelContext ctx = new ModelContext();
                ctx.Employees.Add(emp);
                ctx.SaveChanges();

                return View("FormResult");
            }
            return View();
        }
    }
}