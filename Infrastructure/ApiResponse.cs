using System.Net;

namespace Infrastructure;

public class ApiResponse
{
    public HttpStatusCode StatusCode { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
}

