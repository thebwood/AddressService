using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressService.ClassLibrary.Models
{
    public class Entity
    {
        public Entity()
        {
        }

        public Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
