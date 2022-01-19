using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;
using System.Data.Entity.Validation;
using EntityMVC.Common.DTO.Request.Employees;

namespace EntityMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeesEntities entities = new EmployeesEntities();
        
        public EmployeeController()
        {
            

        }
        public ActionResult Index()
        {
            return View(entities.employees.ToList());
        }
                
        public ActionResult DetailsWithId (int id)
        {
            //get by id from db and map to dto model for view
            CreateEmployeeDTO dto = new CreateEmployeeDTO();
            dto.FirstName = "DUPA 123";
            return RedirectToAction("Details", dto);
        }

        public ActionResult Details(CreateEmployeeDTO model)
        {
            return View(model);
        }

        public ActionResult Create()
        {
            var jobs = entities.jobs.Select(p => new SelectListItem { Text = p.job_title, Value = p.job_id.ToString() }).ToList();
           
            CreateEmployeeDTO model = new CreateEmployeeDTO { JobsDropdown = jobs};
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeDTO employeeDto)
        {          
            
            
            try
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
                    return RedirectToAction("Details", employeeDto);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return View(employeeDto);
            }
        }
}
