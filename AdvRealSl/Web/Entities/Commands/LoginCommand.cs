﻿namespace Web.Entities.Commands
{
    public class LoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
