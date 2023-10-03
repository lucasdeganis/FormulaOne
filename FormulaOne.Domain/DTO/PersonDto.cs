using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Domain.DTO
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? CountryCode { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
    }
}
