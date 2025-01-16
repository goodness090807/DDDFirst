namespace DDDFirst.Domain.SeedWork
{
    public abstract class Entity<TID> : IEntity<TID>
    {
        public TID Id { get; protected set; } = default!;

        protected Entity(TID id)
        {
            if (EqualityComparer<TID>.Default.Equals(id, default))
            {
                throw new InvalidOperationException("Id cannot be null");
            }
            Id = id;
        }

        // protected 建構子，避免外部直接建立 Entity
        protected Entity()
        {
        }

        /// <summary>
        /// 實體是否是新的，且確認ID應不能Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TID> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
