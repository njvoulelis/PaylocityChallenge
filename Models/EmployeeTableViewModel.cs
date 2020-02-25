using System.Collections.Generic;

namespace PaylocityChallenge.Models
{
    public class EmployeeTableViewModel
    {
        public List<Employee> ViewEmployeeList {get;set;}
        public double ViewTotaledSalaries {get;set;}
        public double ViewTotalWithholdingByEmployer {get;set;}

    }
}