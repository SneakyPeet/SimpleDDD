namespace SimpleDDD.Domain.Abstractions
{
    //Todo Choose an entity below that suits your needs and rename it to IEntity
    //http://sneakycode.net/entity-is-for-identity/

    /// <summary>
    /// An Entity is responsible for tracking it's state and the rules regulating it's lifecycle.
    /// It is identified by it's Id and not by other attributes
    /// Use if various identity types are going to be used.
    /// </summary>
    /// <typeparam name="TKey">Identity Type</typeparam>
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }

    /// <summary>
    /// An Entity is responsible for tracking it's state and the rules regulating it's lifecycle.
    /// It is identified by it's Id and not by other attributes
    /// Use if single identity type is used across all entities.
    /// </summary>
    public interface ISimpleEntity
    {
        int Id { get; }
    }

    /// <summary>
    /// An Entity is responsible for tracking it's state and the rules regulating it's lifecycle.
    /// It is identified by it's Id and not by other attributes
    /// Use if Identity comparison is not trivial
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IComparableEntity<out TKey, in TEntity>
    {
        TKey Id { get; }

        bool IsSameAs(TEntity entity);
    }

    /// <summary>
    /// An Entity is responsible for tracking it's state and the rules regulating it's lifecycle.
    /// It is identified by it's Id and not by other attributes
    /// Use if Identity comparison is not trivial. But not all Entities require complex comparison
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IComparableInheritingEntity<out TKey, in TEntity> : IEntity<TKey>
    {
        bool IsSameAs(TEntity entity);
    }
}