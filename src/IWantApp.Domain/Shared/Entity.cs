using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Domain.Shared
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedOn { get; set; }
    }
}
