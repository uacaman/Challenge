namespace Core.Interfaces
{
    /// <summary>
    /// Defines the CRUD operations for an entity.
    /// This interface allows for CRUD operations to be injected by the DI (Dependency Injection) container.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface ICrud<T>
    {
        /// <summary>
        /// Asynchronously retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier, or null if not found.</returns>
        Task<T?> ByIdAsync(int id);

        /// <summary>
        /// Asynchronously adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Removes an existing entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Asynchronously retrieves all entities.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        Task<List<T>> AllAsync();
        Task<List<T>> AllNoTrakingAsync();
    }
}
