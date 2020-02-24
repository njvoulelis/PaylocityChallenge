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
            .Include(e => e.RelatedDependents)
            .OrderBy(e => e.FirstName)
            .ToList();
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

            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(NewEmployee);
                dbContext.SaveChanges();
                return Redirect("/");
            }
            return View("AddEmployeeForm");
        }

        [HttpGet("/{id}/deleteemployee")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee EmployeeToDelete = dbContext.Employees.FirstOrDefault(e => e.EmpId == id);
            dbContext.Employees.Remove(EmployeeToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("EmployeeTable");

        }

        [HttpGet("/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            Employee RetEmployee = dbContext.Employees
            .Include(e => e.RelatedDependents)
            .FirstOrDefault(e => e.EmpId == id);

            RetEmployee.CalculateEmployeeHealthcare();

            foreach (Dependent d in RetEmployee.RelatedDependents)
            {
                RetEmployee.TotalCostPerYear += d.DependentHealthcarePerYear();
                RetEmployee.TotalCostPerPaycheck += d.DependentHealthcarePerPaycheck();
            }

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
            if (ModelState.IsValid)
            {
                employeeDependentViewModel.ViewDependent.EmpId = id;
                dbContext.Dependents.Add(employeeDependentViewModel.ViewDependent);
                dbContext.SaveChanges();
                return Redirect($"/{id}");
            }
            Employee RetEmployee = dbContext.Employees
            .FirstOrDefault(e => e.EmpId == id);

            EmployeeDependentViewModel employeeDependentViewModelForValidation = new EmployeeDependentViewModel()
            {
                ViewEmployee = RetEmployee
            };
            
            return View("AddDependentForm", employeeDependentViewModelForValidation);
        }

        [HttpGet("/{id}/deletedependent/")]
        public IActionResult DeleteDependent(int id)
        {
            Dependent DependentToDelete = dbContext.Dependents.FirstOrDefault(d => d.DepId == id);
            int empId = DependentToDelete.EmpId;
            dbContext.Dependents.Remove(DependentToDelete);
            dbContext.SaveChanges();
            return Redirect($"/{DependentToDelete.EmpId}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
