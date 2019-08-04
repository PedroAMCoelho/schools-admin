using SchoolsAdmin.Contracts;
using SchoolsAdmin.Domain.DTO;
using SchoolsAdmin.Domain.Entities.Extensions;
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
                .DefaultIfEmpty(new School("A definir"))
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

        //public void CreateSchool(School school)
        //{
        //    school.Id = Guid.NewGuid();
        //    Create(school);
        //}

        public void UpdateSchool(School dbSchool, School school)
        {
            dbSchool.Map(school);
            Update(dbSchool);
        }

    }
}
