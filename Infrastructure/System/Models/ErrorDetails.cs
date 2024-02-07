using System.Text.Json;

namespace mongodb_base_api.Infrastructure.System.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}