﻿namespace Authenticator.Application.Models
{
    public class UserAppModel
    {
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = [];
    }
}
