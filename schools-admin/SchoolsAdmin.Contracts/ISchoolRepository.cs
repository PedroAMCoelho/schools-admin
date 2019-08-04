using SchoolsAdmin.Domain.DTO;
using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Contracts
{
    public interface ISchoolRepository : IRepositoryBase<School>
    {
        IEnumerable<School> GetAllSchools();
        School GetSchoolById(Guid schoolId);
        SchoolDTO GetSchoolWithDetails(Guid schoolId);
    }
}
