﻿using System;
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

        public ActionResult Details(jobs Job)
        {
            return View(Job);
        }
        [HttpGet]
        public ActionResult DetailsWithId(int id)
        {
            var data = job.jobs.Where(p => p.job_id == id).FirstOrDefault();
            if(data == null)
            {
                HttpNotFound();
            }
            return RedirectToAction("Details", data);
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
                return RedirectToAction("Details", Job);
            }

            return View(Job);
        }



    }
}