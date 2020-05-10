using MVC_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.Action = "Add";
            return View();
        }

        ModelContext ctx = new ModelContext();

        [HttpPost]
        public ViewResult EmployeeForm(Employee employee)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                Employee emp = new Employee(employee.Name, employee.Gender, employee.Email, employee.Address, employee.Salary);
                ctx.Employees.Add(emp);
                ctx.SaveChanges();

                return View("FormResult");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeEditForm(int id)
        {
            ViewBag.Action = "Edit";
            Employee emp = ctx.Employees.Find(id);
            if(emp != null)
            {
                return View("EmployeeForm", emp);
            }
            return HttpNotFound("Employee not found");
        }

        [HttpPost]
        public ActionResult EmployeeEditForm(Employee emp)
        {
            ViewBag.Action = "Edit";
            if (ModelState.IsValid)
            {
                ctx.Employees.Attach(emp);
                ctx.Entry(emp).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee emp = ctx.Employees.Find(id);
            if (emp != null)
            {
                ctx.Employees.Remove(emp);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return HttpNotFound("Employee not found");
        }
        //[ChildActionOnly]
        //public PartialViewResult EmployeePartial(int id)
        //{
        //    Employee emp = context.Employees.Find(id);
        //    return PartialView("_EmployeePartial", emp);
        //}
    }
}