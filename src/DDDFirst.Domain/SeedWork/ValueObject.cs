using System.Diagnostics.CodeAnalysis;

namespace DDDFirst.Domain.SeedWork
{
    public abstract class ValueObject : IEqualityComparer<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();


        public bool Equals(ValueObject? x, ValueObject? y) => throw new NotImplementedException();
        public int GetHashCode([DisallowNull] ValueObject obj)
        {

            return GetEqualityComponents()
                .Aggregate(17, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 31 + (obj != null ? obj.GetHashCode() : 0);
                    }
                });
        }
    }
}
