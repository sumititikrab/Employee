using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace Test_WebApplication.Models
{
    public partial class UpdateDepartmentData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Departments(DepartmentName)Values('IT')");
            Sql("Insert into Departments(DepartmentName)Values('HR')");
            Sql("Insert into Departments(DepartmentName)Values('Payroll')");
            Sql("Insert into Departments(DepartmentName)Values('Talent Acquisition')");
            Sql("Insert into Departments(DepartmentName)Values('Training & Development')");
        }

        public override void Down()
        {
        }
    }

    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
