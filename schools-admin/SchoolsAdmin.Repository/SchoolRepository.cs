using SchoolsAdmin.Contracts;
using SchoolsAdmin.Domain.DTO;
using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Repository
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<School> GetAllSchools()
        {
            return FindAll()
                .OrderBy(sc => sc.Name)
                .ToList();
        }

        public School GetSchoolById(Guid schoolId)
        {
            return FindByCondition(school => school.Id.Equals(schoolId))
                .DefaultIfEmpty(new School(GetSchoolById(schoolId).Name))
                .FirstOrDefault();
        }

        public SchoolDTO GetSchoolWithDetails(Guid schoolId)
        {
            return new SchoolDTO(GetSchoolById(schoolId).Name, GetSchoolById(schoolId))
            {
                Classrooms = RepositoryContext.Classrooms
                    .Where(sc => sc.SchoolId == schoolId)
            };
        }
    }
}
