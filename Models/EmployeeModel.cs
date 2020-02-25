using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace PaylocityChallenge.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [RegularExpression(@"^[^±!@£$%^&*_+§¡€#¢§¶•ªº«\\/<>?:;|=.,]{1,20}$", ErrorMessage = "Please only use characters for First name")]
        [MinLength(1, ErrorMessage = "First name must be more than 1 character")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[^±!@£$%^&*_+§¡€#¢§¶•ªº«\\/<>?:;|=.,]{1,20}$", ErrorMessage = "Please only use characters for Last name")]
        [MinLength(1, ErrorMessage = "Last name must be more than 1 character")]
        public string LastName { get; set; }

        public int Salary { get; set; } = 52000;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public double EmployeeCostPerYear { get; set; } = 0;

        [NotMapped]
        public double EmployeeCostPerPaycheck { get; set; } = 0;

        [NotMapped]
        public double TotalCostPerYear { get; set; } = 0;

        [NotMapped]
        public double TotalCostPerPaycheck { get; set; } = 0;
        public void CalculateEmployeeHealthcare()
        {
            if (this.FirstName.ToLower()[0] == 'a')
            {
                this.EmployeeCostPerYear += 900;
                this.TotalCostPerYear += 900;
            }
            else
            {
                this.EmployeeCostPerYear += 1000;
                this.TotalCostPerYear += 1000;
            }
            this.EmployeeCostPerPaycheck += Math.Round((this.EmployeeCostPerYear / 26), 2);
            this.TotalCostPerPaycheck += Math.Round((this.TotalCostPerYear / 26), 2);
            return;
        }
        //  navigator below
        public List<Dependent> RelatedDependents { get; set; }

    }
}