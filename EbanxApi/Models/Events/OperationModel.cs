using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EbanxApi.Models.Events
{
    public class OperationModel
    {
        [Required]
        public string Type { get; set; }

        public string? Destination { get; set; }

        public string? Origin { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
