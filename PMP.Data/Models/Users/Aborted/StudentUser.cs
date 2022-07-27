using Microsoft.AspNetCore.Identity;

namespace PMP.Data;

public class StudentUser : IdentityUser
{
    /// <summary>
    /// The year note of a student
    /// </summary>
    public int Moyenne { get; set; }

    /// <summary>
    /// The id of the team that the student is in, if any
    /// </summary>
    public string? EquipeId { get; set; }

    /// <summary>
    /// The list of invitations that we received from teams
    /// </summary>
    public List<Equipe>? EquipeInvitations { get; set; }

}
