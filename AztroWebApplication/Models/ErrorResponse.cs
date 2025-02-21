namespace AztroWebApplication.Models
{
    public class ErrorResponse
    {
        public string Titulo { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;
    }

}