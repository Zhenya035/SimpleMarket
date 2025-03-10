using SimpleMarket.Core.Enums;

namespace SimpleMarket.Application.DTOs;

public class UserRequest
{
    public Role Role { get; set; } = Role.User;
    public string Username { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}