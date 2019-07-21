using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Shared.Entities;

namespace WebAPI.Models.Entities
{
    public class School : Entity
    {
        private readonly ICollection<Classroom> _classrooms;

        public School(string name) : base(name)
        {
            _classrooms = new Collection<Classroom>();
        }

        public virtual IReadOnlyCollection<Classroom> Classrooms { get { return _classrooms.ToArray(); } }
        public int QuantityOfClasses { get { return _classrooms.Count; } }


        public void AddClassroom(Classroom c)
        {            
            _classrooms.Add(c);
        }
    }

    
}

