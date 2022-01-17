using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Controllers
{
    public class DependentsController : Controller
    {
        // GET: Dependents
        public ActionResult Index()
        {
            var dependents = new EmployeesEntities();
            return View(dependents.dependents.ToList());
        }
    }
}