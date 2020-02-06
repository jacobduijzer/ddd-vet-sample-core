using System;
namespace FrontDesk.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
                throw new ArgumentException("The ID cannot be the type's default value.", "id");

            Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        // For simple entities, this may suffice
        // As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        public override bool Equals(object otherObject) =>
            otherObject switch
            {
                Entity<TId> entity => this.Equals(entity),
                _ => base.Equals(otherObject)
            };

        public override int GetHashCode() => Id.GetHashCode();

        public bool Equals(Entity<TId> other) =>
            other switch
            {
                null => false,
                _ => Id.Equals(other.Id)
            };
    }
}
