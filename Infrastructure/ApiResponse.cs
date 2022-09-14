namespace Infrastructure;

public class ApiResponse
{
    public int StatusCode { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
}

