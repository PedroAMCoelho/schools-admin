using SchoolsAdmin.Contracts;
using SchoolsAdmin.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IClassroomRepository _classroom;
        private ISchoolRepository _school;

        public IClassroomRepository Classroom
        {
            get
            {
                if (_classroom == null)
                {
                    _classroom = new ClassroomRepository(_repoContext);
                }

                return _classroom;
            }
        }

        public ISchoolRepository School
        {
            get
            {
                if (_school == null)
                {
                    _school = new SchoolRepository(_repoContext);
                }

                return _school;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
