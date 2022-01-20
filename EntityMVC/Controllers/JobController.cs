using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        EmployeesEntities job = new EmployeesEntities();
        public ActionResult Index()
        {

            return View(job.jobs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(jobs Job)
        {
            if (ModelState.IsValid)
            {
                job.jobs.Add(Job);
                job.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



    }
}