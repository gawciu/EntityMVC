using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Common.DTO.Request.Employees
{
    public class EditEmployeeDTO
    {
        //Needed to view 
        public List<SelectListItem> JobsDropdown { get; set; }
        public List<SelectListItem> DepartmentIdDropdown { get; set; }

        //Needed to save
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int JobId { get; set; }
        public decimal Salary { get; set; }

        public EditEmployeeDTO(employees model)
        {
            Id = model.employee_id;
            FirstName = model.first_name;
            LastName = model.last_name;
            Email = model.email;
            PhoneNumber = model.phone_number;
            HireDate = model.hire_date;
            JobId = model.job_id;
            Salary = model.salary;
            DepartmentId = model.department_id;
            ManagerId = model.manager_id;
        }
        public EditEmployeeDTO()
        {

        }
        

    }
}