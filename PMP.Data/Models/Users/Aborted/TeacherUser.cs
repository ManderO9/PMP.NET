using Microsoft.AspNetCore.Identity;

namespace PMP.Data;

public class TeacherUser : IdentityUser
{
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
    /// The list of soutenances that the teacher will be a <see cref="Jury"/> on
    /// </summary>
    public List<Soutenance>? Soutenances { get; set; }

}
