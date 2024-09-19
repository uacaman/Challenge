using System.ComponentModel.DataAnnotations;

namespace Business.Commands
{
    public class AddTaskCommand
    {
        public required string ClientId { get; set; } 

        public required string Name { get; set; } 
    }
}
