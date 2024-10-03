using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Initials { get; set; }
}
