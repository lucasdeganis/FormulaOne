using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Domain.Entities
{
    public class Person : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? CountryCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
    }
}
