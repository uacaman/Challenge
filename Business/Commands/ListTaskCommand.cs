using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class ListTaskCommand
    {
        public required string ClientId { get; set; } 
    }
}
