using SchoolsAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.Entities.Models
{
    public class Classroom : Entity
    {
        

        public Classroom(string name) : base(name)
        {            
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            IsActive = true;
        }

        public Classroom(string name, School school) : base(name)
        {            
            School = school;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            IsActive = true;
        }

        [Required(ErrorMessage = "School Id is required")]
        public Guid SchoolId { get; private set; }

        public virtual School School { get; private set; }

        [Required(ErrorMessage = "Create Date is required")]
        public DateTime CreateDate { get; private set; }

        [Required(ErrorMessage = "Last Update Date is required")]
        public DateTime LastUpdateDate { get; private set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; private set; }

        public void Activate()
        {
            IsActive = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            IsActive = false;
            LastUpdateDate = DateTime.Now;
        }
    }

}
