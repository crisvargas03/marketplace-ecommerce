﻿namespace marketplaceAPI.BLL.DTOs.UtilsModels
{
    public class JWTConfig
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationTimeMinutes { get; set; } 
    }
}
