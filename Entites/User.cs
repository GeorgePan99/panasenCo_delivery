using System;
using Microsoft.AspNetCore.Identity;

namespace Entites;

public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public User(string userName, string email)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be empty");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty");
        UserName = userName;
        Email = email;
    }
}