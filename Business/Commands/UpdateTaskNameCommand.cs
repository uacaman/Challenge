using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class UpdateTaskNameCommand
    {
        public int Id { get; set; }

        public required string ClientId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

    }
}
