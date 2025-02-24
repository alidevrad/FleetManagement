namespace FleetManagement.Infrastructure.Authentication.DTOS;

public class AuthResult
{
    public bool Success { get; }
    public string Message { get; }
    public string Token { get; }

    public AuthResult(bool success, string message, string token = "")
    {
        Success = success;
        Message = message;
        Token = token;
    }
}