using SchoolsAdmin.Contracts;
using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Repository
{
    public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Classroom> GetAllClassrooms()
        {
            return FindAll()
                .OrderBy(cr => cr.Name)
                .ToList();
        }

        public Classroom GetClassroomById(Guid classroomId)
        {
            return FindByCondition(cr => cr.Id.Equals(classroomId))
                    .DefaultIfEmpty(new Classroom(null))
                    .FirstOrDefault();
        }

        public IEnumerable<Classroom> ClassroomsBySchool(Guid schoolId)
        {
            return FindByCondition(cr => cr.SchoolId.Equals(schoolId)).ToList();
        }
    }
}
