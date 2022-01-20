using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;
using System.Data.Entity.Validation;
using EntityMVC.Common.DTO.Request.Employees;
using System.Data.Entity;

namespace EntityMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        readonly EmployeesEntities entities = new EmployeesEntities();



        public ActionResult Index()
        {
            return View(entities.employees.ToList());
        }

        public ActionResult DetailsWithId(int id)
        {
            var data = entities.employees.Where(p => p.employee_id == id).FirstOrDefault();
            if (data == null)
            {
                HttpNotFound();
            }
            return RedirectToAction("Details", data);
        }

        public ActionResult Details(employees model)
        {
            return View(model);
        }

        public ActionResult Create()
        {
            var jobs = entities.jobs.Select(p => new SelectListItem { Text = p.job_title, Value = p.job_id.ToString() }).ToList();
            var departments = entities.departments.Select(p => new SelectListItem { Text = p.department_name, Value = p.department_id.ToString() }).ToList();


            CreateEmployeeDTO model = new CreateEmployeeDTO { JobsDropdown = jobs, DepartmentIdDropdown = departments };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeDTO employeeDto)
        { 
            if (ModelState.IsValid)
            {
                var dbModel = new employees
                {
                    first_name = employeeDto.FirstName,
                    last_name = employeeDto.LastName,
                    email = employeeDto.Email,
                    phone_number = employeeDto.PhoneNumber,
                    hire_date = employeeDto.HireDate,
                    job_id = employeeDto.JobId,
                    salary = employeeDto.Salary

                };
                entities.employees.Add(dbModel);
                entities.SaveChanges();
                employeeDto.Id = dbModel.employee_id;

                return RedirectToAction("DetailsWithId", new { id = employeeDto.Id });
            }
            return View(employeeDto);

        }

        public ActionResult Edit(int id)
        {
            var data = entities.employees.
                Where(p => p.employee_id == id).
                FirstOrDefault();
            
            EditEmployeeDTO model = new EditEmployeeDTO(data);
            var jobs = entities.jobs.Select(p => new SelectListItem { Text = p.job_title, Value = p.job_id.ToString() }).ToList();
            var departments = entities.departments.Select(p => new SelectListItem { Text = p.department_name, Value = p.department_id.ToString() }).ToList();
            model.JobsDropdown = jobs;
            model.DepartmentIdDropdown = departments;
            
            return View(model);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(EditEmployeeDTO model)
        {
            employees finalModel = new employees
            {
                employee_id = model.Id,
                first_name = model.FirstName,
                last_name = model.LastName,
                email = model.Email,
                phone_number = model.PhoneNumber,
                hire_date = model.HireDate,
                job_id = model.JobId,
                salary = model.Salary,
                department_id = model.DepartmentId,
                manager_id = model.ManagerId
                
                
            };
            entities.Entry(finalModel).State = EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
