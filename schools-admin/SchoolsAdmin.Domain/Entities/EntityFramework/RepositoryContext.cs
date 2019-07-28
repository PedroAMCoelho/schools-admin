using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAdmin.Domain.Entities.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
