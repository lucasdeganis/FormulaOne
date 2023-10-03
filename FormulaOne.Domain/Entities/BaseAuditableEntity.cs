﻿using FormulaOne.Domain.Entities.Shared;

namespace FormulaOne.Domain.Entities
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
