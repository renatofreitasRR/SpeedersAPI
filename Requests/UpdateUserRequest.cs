﻿namespace SpeedersAPI.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
