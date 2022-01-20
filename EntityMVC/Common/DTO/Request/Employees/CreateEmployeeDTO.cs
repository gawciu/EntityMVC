using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Common.DTO.Request.Employees
{
    public class CreateEmployeeDTO
    {
        //Needed to view 
        public List<SelectListItem> JobsDropdown { get; set; }

        //Needed to save
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int JobId { get; set; }
        public decimal Salary { get; set; }

        public CreateEmployeeDTO(employees model)
        {
            Id = model.employee_id;
            FirstName = model.first_name;
            LastName = model.last_name;
            Email = model.email;
            PhoneNumber = model.phone_number;
            HireDate = model.hire_date;
            JobId = model.job_id;
            Salary = model.salary;
        }
        public CreateEmployeeDTO()
        {

        }
    }
}