using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityMVC.Models;

namespace EntityMVC.Common.DTO.Request.Employees
{
    public class EditEmployeeDTO : CreateEmployeeDTO
    {
       

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