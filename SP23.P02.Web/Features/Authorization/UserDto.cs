using System;
namespace SP23.P02.Web.Features.Authorization;

public class UserDto
{
    public int Id { get; set; }
    //what is =string.empty
    public string UserName { get; set; } = string.Empty;
    public string[] Roles { get; set; } = Array.Empty<string>();
}

