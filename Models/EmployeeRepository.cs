using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_WebApplication.Models
{
    public class EmployeeRepository
    {
        public List<Department> GetDepartments()
        {
            EmployeeModel employeeModelDBContext = new EmployeeModel();
            return employeeModelDBContext.Departments.ToList();
        }
    }
}