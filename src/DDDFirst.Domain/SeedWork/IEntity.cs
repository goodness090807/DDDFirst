namespace DDDFirst.Domain.SeedWork
{
    public interface IEntity<out TID>
    {
        TID Id { get; }
    }
}
