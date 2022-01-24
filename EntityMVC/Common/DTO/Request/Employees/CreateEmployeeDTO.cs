using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<SelectListItem> DepartmentIdDropdown { get; set; }

        //Needed to save
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please,use only alphabet characters")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please,use only alphabet characters")]


        public string LastName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [EmailAddress(ErrorMessage = "This is not a correct email address")]
        [StringLength(40)]

        public string Email { get; set; }
        [StringLength(10)]

        [Range(0, Int64.MaxValue,ErrorMessage = "Phone numer should not contain characters")]
        public string PhoneNumber { get; set; }
        public int? DepartmentId { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public int JobId { get; set; }
        [Range(0, 100000, ErrorMessage = "Only numbers to 100K")]
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }

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
            DepartmentId = model.department_id;

        }
        public CreateEmployeeDTO()
        {

        }
    }
}