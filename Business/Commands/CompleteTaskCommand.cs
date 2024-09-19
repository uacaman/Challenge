using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class CompleteTaskCommand
    {
        public int Id { get; set; }

        public required string ClientId { get; set; } 
    }
}
