using Microsoft.AspNetCore.Identity;

namespace PMP.Data;

/// <summary>
/// The object representing the user of our application
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// The domain of an entreprise
    /// </summary>
    public string? Domaine { get; set; }

    /// <summary>
    /// The address of an entreprise
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The year note of a student
    /// </summary>
    public int Moyenne { get; set; }

    /// <summary>
    /// The grade of a teacher
    /// </summary>
    public Grade Grade { get; set; }

    /// <summary>
    /// The specialite of a teacher
    /// </summary>
    public string? Specialite { get; set; }

    /// <summary>
    /// If the teacher can be a jury or not
    /// </summary>
    public bool CanBeJury { get; set; }

    /// <summary>
    /// If the teacher can be encadreur or not
    /// </summary>
    public bool CanBeEncadreur { get; set; }

    /// <summary>
    /// The id of the team that the student is in, if any
    /// </summary>
    public string? EquipeId { get; set; }

    /// <summary>
    /// The list of invitations that we received from teams
    /// </summary>
    public List<Equipe>? EquipeInvitations { get; set; }

    /// <summary>
    /// The list of soutenances that the teacher will be a <see cref="Jury"/> on
    /// </summary>
    public List<Soutenance>? Soutenances { get; set; }

}
