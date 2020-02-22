using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace PaylocityChallenge.Models
{
    public class EmployeeDependentViewModel
    {
        public Employee ViewEmployee {get;set;}

        public Dependent ViewDependent {get;set;}
        
    }
}