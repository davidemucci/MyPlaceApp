using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Entities
{
    public class Building : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int FloorsNumber { get; set; } = 1;

        public List<Office>? Offices { get; set; } = new List<Office>();
        public List<Building> Buildings { get; set; } = new List<Building>();

        // TODO
        // public List<Administrator> Admins {get;set;}

    }
}
