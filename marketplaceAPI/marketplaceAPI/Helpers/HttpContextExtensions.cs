namespace marketplaceAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public static (string userId, string roleId) GetUserClaims(this HttpContext context)
        {
            var userId = context.Request.Headers["User-Id"].FirstOrDefault() ?? string.Empty;
            var roleId = context.Request.Headers["Role-Id"].FirstOrDefault() ?? string.Empty;

            return (userId, roleId);
        }
    }
}
