using FleetManagement.Domain.Models.Users;
using FleetManagement.Domain.Models.Users.Repostitories;
using FleetManagement.Infrastructure.Authentication.Configurations;
using FleetManagement.Infrastructure.Authentication.DTOS;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FleetManagement.Infrastructure.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly AuthConfig _authConfig;

    public AuthService(IUserCommandRepository userCommandRepository,
                       IUserQueryRepository userQueryRepository,
                       IOptions<AuthConfig> authConfig)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _authConfig = authConfig.Value;
    }

    public async Task<AuthResult> Register(string userName,
                                           string firstName,
                                           string lastName,
                                           string email,
                                           string password)
    {
        var existingUser = await _userQueryRepository.GetByExpressionAsync(u => u.UserName == userName || u.Email == email);
        if (existingUser != null)
            return new AuthResult(false, "User already exists");

        var salt = BCrypt.Net.BCrypt.GenerateSalt();

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        var user = new User(userName, firstName, lastName, email, hashedPassword, salt, DateTime.UtcNow, Guid.NewGuid());

        await _userCommandRepository.AddAsync(user);
        await _userCommandRepository.SaveChangesAsync();

        return new AuthResult(true, "User registered successfully");
    }

    public async Task<AuthResult> Login(string userName, string password)
    {
        var user = await _userQueryRepository.GetByExpressionAsync(u => u.UserName == userName);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return new AuthResult(false, "Invalid username or password");

        var token = GenerateJwtToken(user);
        return new AuthResult(true, "Login successful", token);
    }

    private string GenerateJwtToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_authConfig.TokenKey);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("UserId", user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_authConfig.TokenTimeout),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}