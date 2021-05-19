using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Test_WebApplication.Models
{
    public partial class EmployeeDepartmentModels : DbMigration
    {
       
         public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                {
                    DepartmentId = c.Guid(nullable: false, identity: true),
                    DepartmentName = c.String(),
                })
                .PrimaryKey(t => t.DepartmentId);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    EmployeeId = c.Guid(nullable: false, identity: true),
                    EmployeeName = c.String(),
                    EmployeeDesignation = c.String(),
                    EmployeeAddress = c.String(),
                    EmployeePassport = c.String(),
                    EmployeePhone = c.Int(nullable: false),
                    EmployeeGender = c.String(),
                    City = c.String(),
                    Project = c.String(),
                    CompanyName = c.String(),
                    PinCode = c.Int(nullable: false),
                    DepartmentId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }

    public partial class UpdateEmployeeData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Employees(EmployeeName,EmployeeDesignation,EmployeeAddress,EmployeePassport,EmployeePhone,EmployeeGender,City,Project,CompanyName,PinCode,DepartmentId)" +
                "Values('KM','S.E','Hyderabad','K849271',123456789,'Male','Hyderabad','Automation','Infosys',500045,1)");
        }

        public override void Down()
        {
        }
    }

    public class EmployeeModel : DbContext
    {
        // Your context has been configured to use a 'EmployeeModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Test_WebApplication.Models.EmployeeModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmployeeModel' 
        // connection string in the application configuration file.
        public EmployeeModel()
            : base("name=EmployeeModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Designation")]
        public string EmployeeDesignation { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Passport")]
        public string EmployeePassport { get; set; }
        [Display(Name = "Phone")]
        public int EmployeePhone { get; set; }
        [Display(Name = "Gender")]
        public Gender EmployeeGender { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Project")]
        public string Project { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Pin Code")]
        public int PinCode { get; set; }
        [Display(Name = "Dept Name")]
        public int DepartmentId { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}