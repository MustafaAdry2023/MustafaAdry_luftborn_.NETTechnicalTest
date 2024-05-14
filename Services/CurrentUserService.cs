using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace Services
{
    public class CurrentUserService : ICurrentUserService
    {

        ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpAccessor)
        {
            user = httpAccessor.HttpContext?.User;
        }
        private string userId;

        public string UserId
        {
            set { userId = value; }
            get
            {
                if (userId == null)
                {
                    string id = user?.Claims?.FirstOrDefault(obj => obj.Type == "UserId")?.Value;
                    return id;
                }
                return userId;
            }
        }

        public Guid Id => string.IsNullOrWhiteSpace(UserId) ? Guid.Empty : Guid.Parse(UserId);

        public string Email =>  user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;

        public string Name => user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
    }
}
