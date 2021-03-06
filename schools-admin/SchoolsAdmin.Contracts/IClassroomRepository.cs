﻿using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Contracts
{
    public interface IClassroomRepository : IRepositoryBase<Classroom>
    {
        IEnumerable<Classroom> GetAllClassrooms();
        Classroom GetClassroomById(Guid classroomId);
        IEnumerable<Classroom> ClassroomsBySchool(Guid schoolId);
    }
}
