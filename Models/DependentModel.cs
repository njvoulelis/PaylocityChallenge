using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace PaylocityChallenge.Models
{
    public class Dependent
    {
        [Key]
        public int DepId { get; set; }

        [Required]
        [RegularExpression(@"^[^±!@£$%^&*_+§¡€#¢§¶•ªº«\\/<>?:;|=.,]{1,20}$", ErrorMessage = "Please only use characters for First name")]
        [MinLength(1, ErrorMessage = "First name must be more than 1 character")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[^±!@£$%^&*_+§¡€#¢§¶•ªº«\\/<>?:;|=.,]{1,20}$", ErrorMessage = "Please only use characters for Last name")]
        [MinLength(1, ErrorMessage = "Last name must be more than 1 character")]
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public double CostPerYear { get; set; } = 0;

        [NotMapped]
        public double CostPerPaycheck { get; set; } = 0;

        public double DependentHealthcarePerYear()
        {
            if (this.FirstName.ToLower()[0] == 'a')
            {
                this.CostPerYear += 450;
                return this.CostPerYear;
            }
            this.CostPerYear += 500;
            return this.CostPerYear;
        }
        public double DependentHealthcarePerPaycheck()
        {
            this.CostPerPaycheck += Math.Round((this.CostPerYear / 26), 2);
            return this.CostPerPaycheck;
        }

        //  foreign key below
        public int EmpId { get; set; }

        //  navigator below
        public Employee SalaryEmployee { get; set; }

    }
}