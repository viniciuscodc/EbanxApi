using System.Text.Json.Serialization;

namespace EbanxApi.Models.Events
{
    public class OperationResultModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account Origin { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account Destination { get; set; }
    }
}
