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
        [MinLength(1, ErrorMessage="Name must be more than 1 character.")]
        public string Name {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //  navigator below
        public List<Dependent> RelatedDependents {get;set;}

    }
}