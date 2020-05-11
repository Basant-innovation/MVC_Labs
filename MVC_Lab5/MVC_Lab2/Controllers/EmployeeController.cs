using MVC_Lab2.Models;
using MVC_Lab2.ViewModals;
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
            ViewBag.Action = "Add";
            EmployeeViewModal empViewModal = new EmployeeViewModal
            {
                Employees = context.Employees.ToList()
        };
            return View(empViewModal);
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
                ctx.Employees.Add(employee);
                ctx.SaveChanges();

                return View("FormResult");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();

                return PartialView("_EmployeePartial", employee);
            }
            return Json(ModelState);
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