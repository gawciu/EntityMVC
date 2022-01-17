using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departmens
        public ActionResult Index()
        {
            var departmens = new EmployeesEntities();
            return View(departmens.departments.ToList());
        }
    }
}