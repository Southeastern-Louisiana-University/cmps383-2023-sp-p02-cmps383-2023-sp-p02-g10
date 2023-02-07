using System;
using Microsoft.AspNetCore.Identity;

namespace SP23.P02.Web.Features.Authorization;

public class User : IdentityUser<int>
{
    public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
}

