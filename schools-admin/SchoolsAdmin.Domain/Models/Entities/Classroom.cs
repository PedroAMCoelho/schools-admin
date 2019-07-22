using SchoolsAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.Models.Entities
{
    public class Classroom : Entity
    {

        public Classroom(string name) : base(name)
        {            
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = true;
        }

        public Classroom(string name, School school) : base(name)
        {            
            School = school;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = true;
        }

        public Guid SchoolId { get; private set; }
        public virtual School School { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }

}
