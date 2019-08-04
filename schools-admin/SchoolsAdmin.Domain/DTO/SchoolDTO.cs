using SchoolsAdmin.Domain.Entities.Models;
using SchoolsAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.DTO
{
    public class SchoolDTO : Entity
    {
        public IEnumerable<Classroom> Classrooms { get; set; }        

        public SchoolDTO(string name) : base(name) { }

        public SchoolDTO(string name, School school) : base(name)
        {
            Id = school.Id;
            Name = school.Name;                     
        }

        
    }
}
