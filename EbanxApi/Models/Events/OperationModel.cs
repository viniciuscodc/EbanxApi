using System.ComponentModel.DataAnnotations;

namespace EbanxApi.Models.Events
{
    public class OperationModel
    {
        [Required]
        public string Type { get; set; } = null!;

        public string? Destination { get; set; }

        public string? Origin { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
