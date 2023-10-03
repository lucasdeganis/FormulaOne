using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Domain.DTO
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public int Season { get; set; }
        public CategoryEnum Category { get; set; }
        public Person Person { get; set; }
        public Team Team { get; set; }
        public int NumberCar { get; set; }
        public int Points { get; set; }
    }
}
