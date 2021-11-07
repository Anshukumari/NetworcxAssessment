using EmpManagement.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Model
{
    public class EmpDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EmployeeDbContext>();
                if(!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee()
                        {
                            Id = 1,
                            Name = "John",
                            Gender = "Male",
                            Age = 34,
                            Salary = 5600000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Harry",
                            Gender = "Male",
                            Age = 34,
                            Salary = 5800000
                        },
                        new Employee()
                        {
                             Id = 3,
                             Name = "Marie",
                             Gender = "Female",
                             Age = 30,
                             Salary = 5600000
                        }
                        );
                        context.SaveChanges();
                }
            }
        }
    }
}
