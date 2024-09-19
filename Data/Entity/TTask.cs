using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    /// <summary>
    /// Task entity on EF. Each entity has to implement IEntity to allow for basic CRUD operations 
    /// </summary>
    public class TTask : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public bool Completed { get; set; } = false;
    }
}
