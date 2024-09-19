using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class DelTaskCommand
    {
        public int Id { get; set; }

        public required string ClientId { get; set; }
    }
}
