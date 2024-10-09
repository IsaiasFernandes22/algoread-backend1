#nullable enable

namespace ContentManagementAPI.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; } // Alterado para string? para suportar nulos
        public object? Data { get; set; } // Alterado para object? para suportar nulos
    }
}
