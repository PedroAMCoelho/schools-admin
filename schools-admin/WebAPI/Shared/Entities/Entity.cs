using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Shared.Entities
{
    public abstract class Entity
    {
        protected Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
