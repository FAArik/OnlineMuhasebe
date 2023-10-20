using Microsoft.AspNetCore.Http;
using OnlineMuhasebeServer.Application.Services;

namespace OnlineMuhasebeServer.Infrastructure.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserIdByToken()
        {
            var UserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Contains("authentication"))?.Value;
            return UserId ?? string.Empty;
        }
    }
}
