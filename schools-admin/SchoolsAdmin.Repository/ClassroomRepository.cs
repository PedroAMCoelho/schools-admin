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
            return FindByCondition(classroom => classroom.Id.Equals(classroomId))
                    .DefaultIfEmpty(new Classroom())
                    .FirstOrDefault();
        }
    }
}
