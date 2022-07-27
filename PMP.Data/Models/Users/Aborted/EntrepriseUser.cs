using Microsoft.AspNetCore.Identity;

namespace PMP.Data;

public class EntrepriseUser : IdentityUser
{

    /// <summary>
    /// The domain of an entreprise
    /// </summary>
    public string? Domaine { get; set; }

    /// <summary>
    /// The address of an entreprise
    /// </summary>
    public string? Address { get; set; }
}
