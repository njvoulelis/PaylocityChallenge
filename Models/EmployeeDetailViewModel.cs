namespace PaylocityChallenge.Models
{
    public class EmployeeDetailViewModel
    {
        public Employee ViewEmployee {get;set;}

        public int NetPay {get;set;}
        public int TotalDeduction {get;set;}
        public int Paycheck {get;set;}
        public int DeductionPerPayCheck {get;set;}
    }
}