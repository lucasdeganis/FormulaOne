using FormulaOne.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Domain.Entities
{
    public class Driver : BaseAuditableEntity
    {
        public int Season { get; set; }
        public CategoryEnum Category { get; set; }
        public Person Person { get; set; }
        public Team Team { get; set; }
        public int NumberCar { get; set; }
        public int Points { get; set; }

        public Driver() : base()
        {
            this.Person = new Person();
            this.Team = new Team();
        }
    }
}
