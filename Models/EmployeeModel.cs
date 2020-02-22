using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace PaylocityChallenge.Models
{
    public class Employee
    {
        [Key]
        public int EmpId {get;set;}

        [Required]
        [MinLength(1, ErrorMessage="First name must be more than 1 character.")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(1, ErrorMessage="Last name must be more than 1 character.")]
        public string LastName {get;set;}

        public int Salary {get;set;} = 52000;

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //  navigator below
        public List<Dependent> RelatedDependents {get;set;}

    }
}