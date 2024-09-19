using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class UpdateTaskCommand
    {
        public int Id { get; set; }

        public required string ClientId { get; set; }

        public string? Name { get; set; }

        public bool? Completed { get; set; }
    }
}
