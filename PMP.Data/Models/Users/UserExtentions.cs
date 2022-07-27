using Microsoft.AspNetCore.Identity;

namespace PMP.Data
{
    /// <summary>
    /// Extentions methods for the <see cref="AppUser"/> class
    /// </summary>
    public static class UserExtentions
    {
        /// <summary>
        /// Converts an <see cref="AppUser"/> to the given <typeparamref name="TUser"/> type
        /// </summary>
        /// <typeparam name="TUser">The type to translate the user into</typeparam>
        /// <param name="user">The user to translate</param>
        /// <returns>A new <typeparamref name="TUser"/>, null if we can't translate the user into the type passed in</returns>
        public static TUser? ToUser<TUser>(this AppUser user) where TUser : IdentityUser, new()
        {
            // If we want to translate into an admin user
            if (typeof(TUser) == typeof(AdminUser))
                // Create a new admin user
                return (TUser)(IdentityUser)new AdminUser()
                {
                    // Give the data from the passed in user
                    AccessFailedCount = user.AccessFailedCount,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Id = user.Id,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    NormalizedEmail = user.NormalizedEmail,
                    NormalizedUserName = user.NormalizedUserName,
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    PasswordHash = user.PasswordHash,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    SecurityStamp = user.SecurityStamp,
                    UserName = user.UserName
                };

            // Otherwise, if we want to create a student user
            else if (typeof(TUser) == typeof(StudentUser))
                // Create a new student user
                return (TUser)(IdentityUser)new StudentUser()
                {
                    // Give it the data from the passed in user
                    AccessFailedCount = user.AccessFailedCount,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Id = user.Id,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    NormalizedEmail = user.NormalizedEmail,
                    NormalizedUserName = user.NormalizedUserName,
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    PasswordHash = user.PasswordHash,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    SecurityStamp = user.SecurityStamp,
                    UserName = user.UserName,
                    EquipeId = user.EquipeId,
                    EquipeInvitations = user.EquipeInvitations,
                    Moyenne = user.Moyenne
                };

            // Otherwise, if we want to create an entreprise user
            else if (typeof(TUser) == typeof(EntrepriseUser))
                // Create a new entreprise user
                return (TUser)(IdentityUser)new EntrepriseUser()
                {
                    // Give it the data from the passed in user
                    AccessFailedCount = user.AccessFailedCount,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Id = user.Id,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    NormalizedEmail = user.NormalizedEmail,
                    NormalizedUserName = user.NormalizedUserName,
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    PasswordHash = user.PasswordHash,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    SecurityStamp = user.SecurityStamp,
                    UserName = user.UserName,
                    Address = user.Address,
                    Domaine = user.Domaine
                };

            // Otherwise, if we want to create a teacher user
            else if (typeof(TUser) == typeof(TeacherUser))
                // Create a new teacher user
                return (TUser)(IdentityUser)new TeacherUser()
                {
                    // Give it the data passed in from the user
                    AccessFailedCount = user.AccessFailedCount,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Id = user.Id,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    NormalizedEmail = user.NormalizedEmail,
                    NormalizedUserName = user.NormalizedUserName,
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    PasswordHash = user.PasswordHash,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    SecurityStamp = user.SecurityStamp,
                    UserName = user.UserName,
                    CanBeEncadreur = user.CanBeEncadreur,
                    CanBeJury = user.CanBeJury,
                    Grade = user.Grade,
                    Soutenances = user.Soutenances,
                    Specialite = user.Specialite
                };

            // If no check has passed, we return null
            return null;

        }
    }
}
