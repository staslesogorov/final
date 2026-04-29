namespace api.Dto;

public class ApiResponse<T>
{
    public bool Success => Error == null;
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
