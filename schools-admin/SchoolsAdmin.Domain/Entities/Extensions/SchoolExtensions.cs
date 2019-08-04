using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.Entities.Extensions
{
    public static class SchoolExtensions
    {
        public static void Map(this School dbSchool, School school)
        {
            dbSchool.Id = school.Id;
            dbSchool.Name = school.Name;            
        }
    }
}
