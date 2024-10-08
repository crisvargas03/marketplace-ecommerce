﻿namespace marketplaceAPI.BLL.DTOs.AuthModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }

    public class UserLoginWithCredsDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserRegisterWithCredsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
