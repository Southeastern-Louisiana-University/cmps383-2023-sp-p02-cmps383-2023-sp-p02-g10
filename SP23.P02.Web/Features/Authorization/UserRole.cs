using System;
using Microsoft.AspNetCore.Identity;

namespace SP23.P02.Web.Features.Authorization;

public class UserRole : IdentityUserRole<int>
{
	//public int UserId { get; set; }

	//public User User { get; set; }

	//public int RoleId { get; set; }

	//public Role Role { get; set; }

    public virtual Role? Role { get; set; }
    public virtual User? User { get; set; }

}

