namespace Core.Interfaces
{
    /// <summary>
    /// Represents a base interface for EF entities within the application.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// This property serves as the primary key for the entity in the database.
        int Id { get; set; }
    }
}
