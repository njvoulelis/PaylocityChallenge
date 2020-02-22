using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace PaylocityChallenge.Models
{
    public class Dependent
    {
        [Key]
        public int DepId {get;set;}

        [Required]
        [MinLength(1, ErrorMessage="First name must be more than 1 character.")]
        public string FirstName {get;set;}
        
        [Required]
        [MinLength(1, ErrorMessage="Last name must be more than 1 character.")]
        public string LastName {get;set;}



        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //  foreign key below
        public int EmpId {get;set;}

        //  navigator below
        public Employee SalaryEmployee {get;set;}

    }
}