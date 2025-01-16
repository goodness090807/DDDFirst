using DDDFirst.Domain.SeedWork;

namespace DDDFirst.Domain.Entities.Common
{
    public abstract class BaseAuditableEntity<TID> : Entity<TID>
    {
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
