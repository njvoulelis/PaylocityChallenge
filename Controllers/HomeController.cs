using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaylocityChallenge.Models;

namespace PaylocityChallenge.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("/")]
        public IActionResult EmployeeTable()
        {
            List<Employee> AllEmployees = dbContext.Employees
            .Include(e=>e.RelatedDependents)
            .OrderByDescending(e=>e.FirstName)
            .ToList();
            // EmployeeTableViewModel employeeTableViewModel = new EmployeeTableViewModel()
            // {
            //     ViewEmployeeList = AllEmployees,
            //     Healthcare
            // };
            return View(AllEmployees);
        }

        [HttpGet("add-employee")]
        public IActionResult AddEmployeeForm()
        {
            return View();
        }


        [HttpPost("add-employee")]
        public IActionResult AddEmployeePost(Employee NewEmployee)
        {
            dbContext.Employees.Add(NewEmployee);
            dbContext.SaveChanges();
            return Redirect("/");
        }

        [HttpGet("/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            Employee RetEmployee = dbContext.Employees
            .Include(e => e.RelatedDependents)
            .FirstOrDefault(e => e.EmpId == id);
            return View(RetEmployee);
        }

        [HttpGet("/{id}/add-dependent")]
        public IActionResult AddDependentForm(int id)
        {
            Employee RetEmployee = dbContext.Employees
            .FirstOrDefault(e => e.EmpId == id);

            EmployeeDependentViewModel employeeDependentViewModel = new EmployeeDependentViewModel()
            {
                ViewEmployee = RetEmployee
            };
            return View(employeeDependentViewModel);
        }

        [HttpPost("/{id}/add-dependent")]
        public IActionResult AddDependentPost(EmployeeDependentViewModel employeeDependentViewModel, int id)
        {
            employeeDependentViewModel.ViewDependent.EmpId = id;
            dbContext.Dependents.Add(employeeDependentViewModel.ViewDependent);
            dbContext.SaveChanges();
            return Redirect($"/{id}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
