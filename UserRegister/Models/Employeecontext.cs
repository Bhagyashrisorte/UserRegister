using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UserRegister.Models
{
    public class Employeecontext : DbContext
    {
        public DbSet<Employee> Employees { get; set;}
        
    }
}