using SchoolsAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.Entities.Models
{
    public class School : Entity
    {
        //private readonly ICollection<Classroom> _classrooms;
        //public virtual IReadOnlyCollection<Classroom> Classrooms { get { return _classrooms.ToArray(); } }
        //public int QuantityOfClasses { get { return _classrooms.Count; } }

        public School(string name) : base(name)
        {
            //_classrooms = new Collection<Classroom>();
        }
        
        //#region Methods

        //public void AddClassroom(Classroom c)
        //{
        //    _classrooms.Add(c);
        //} 
        //#endregion
    }

    
}

