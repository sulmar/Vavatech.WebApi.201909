using System;

namespace Vavatech.WebApi.Models
{

    public class Customer : BaseEntity
    {
       
        //private decimal salary;

        //public void SetSalary(decimal value)
        //{
        //    this.salary = value;
        //}

        //public decimal GetSalary()
        //{
        //    return this.salary;
        //}

        //public decimal Salary
        //{
        //    set
        //    {
        //        this.salary = value;
        //    }
        //    get
        //    {
        //        return this.salary;
        //    }
        //}

        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public byte? Age { get; set; }
        public decimal? Salary { get; set; }
        public Gender Gender { get; set; }
        public bool IsRemoved { get; set; }

    }
}
