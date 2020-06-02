using System.Text.Json;

namespace Forum.Api.Models
{
    public class ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public string ToJson()
        {
            return ToString();
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);  
        }
    }
}
