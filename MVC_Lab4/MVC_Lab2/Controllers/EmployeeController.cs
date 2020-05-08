using MVC_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lab2.Controllers
{
    public class EmployeeController : Controller
    {
        ModelContext context = new ModelContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(context.Employees.ToList());
        }

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

        //[ChildActionOnly]
        //public PartialViewResult EmployeePartial(int id)
        //{
        //    Employee emp = context.Employees.Find(id);
        //    return PartialView("_EmployeePartial", emp);
        //}
    }
}