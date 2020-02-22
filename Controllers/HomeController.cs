using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("add-employee")]
        public IActionResult AddEmployeeForm()
        {
            return View();
        }


        [HttpPost("add-employee-post")]
        public IActionResult AddEmployeePost(Employee NewEmployee)
        {
            dbContext.Employees.Add(NewEmployee);
            dbContext.SaveChanges();
            return Redirect("/");
        }

        [HttpGet("/{id}/add-dependent")]
        public IActionResult AddDependentForm(int id)
        {
            Employee RetEmployee = dbContext.Employees
            // .Where(e => e.EmpId == id)
            .FirstOrDefault(e => e.EmpId == id);

            EmployeeDependentViewModel EDViewModel = new EmployeeDependentViewModel()
            {
                ViewEmployee = RetEmployee
            };
            return View(EDViewModel);
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
