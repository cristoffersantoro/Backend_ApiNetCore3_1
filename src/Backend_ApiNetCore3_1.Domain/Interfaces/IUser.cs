
using System.Collections.Generic;
using System.Security.Claims;

namespace Backend_ApiNetCore3_1.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
