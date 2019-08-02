using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Contracts
{
    public interface IRepositoryWrapper
    {
        IClassroomRepository Classroom { get; }
        ISchoolRepository School { get; }
        void Save();
    }
}
