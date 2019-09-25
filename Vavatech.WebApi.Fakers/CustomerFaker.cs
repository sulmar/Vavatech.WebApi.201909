using Bogus;
using System;
using System.Data;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.SecondName, f => f.Person.FirstName);
            RuleFor(p => p.Salary, f => decimal.Round(f.Random.Decimal(100, 1000), 0));
            RuleFor(p => p.Age, f => f.Random.Byte(18, 100));
            RuleFor(p => p.Gender, f => (Gender) f.Person.Gender);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.7f));
            RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.HashPassword, f => "12345");
        }
    }
}
