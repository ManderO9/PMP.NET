using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMP.Data;

namespace PMP.Web;

/// <summary>
/// Controlls different operations related to managing roles, creating them, assiging them...
/// </summary>
public class RolesController : Controller
{
    #region Private Members

    /// <summary>
    /// The user manager to create, delete and get users and manage roles
    /// </summary>
    private UserManager<AppUser> mUserManager;

    /// <summary>
    /// The role manager for the application roles
    /// </summary>
    private RoleManager<AppRole> mRoleManager;

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="userManager">The user manager</param>
    /// <param name="roleManager">The role manager</param>
    public RolesController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        // Set local variables
        mUserManager = userManager;
        mRoleManager = roleManager;
    }

    #endregion

    #region Public Actions

    /// <summary>
    /// Creates a new role and adds it to the persistent store
    /// </summary>
    /// <param name="roleName">The name of the role to add</param>
    /// <returns></returns>
    [Authorize(Roles = RoleType.AdminRole)]
    [Route(Routes.RolesCreateRole)]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        // If we have no role name...
        if (string.IsNullOrWhiteSpace(roleName))
            // Don't do anything
            return Content("Role name can't be empty");

        // Create the role
        var role = new AppRole();

        // Set it's name
        role.Name = roleName;

        // Give it a new id
        role.Id = Guid.NewGuid().ToString("N");

        // Try to add the role
        var result = await mRoleManager.CreateAsync(role);

        // If we succeeded...
        if (result.Succeeded)
            // Return successful
            return Content("done");

        // Otherwise...

        // Set the data of the error page
        ErrorController.ErrorDataModel = ErrorHelper.GetErrors(result, $"failed to add the specified role: \"{roleName}\"");

        // Redirect to the error page
        return Redirect(Routes.ErrorPage);

    }

    /// <summary>
    /// Adds the specified role to the user passed in
    /// </summary>
    /// <param name="username">The username of the user to add the role to</param>
    /// <param name="roleName">The role to add</param>
    /// <returns></returns>
    [Authorize(Roles = RoleType.AdminRole)]
    [Route(Routes.RolesAddRole)]
    public async Task<IActionResult> AddRole(string username, string roleName)
    {
        // TODO: check if the roles exists and is one of our roles

        // If we have no role name...
        if (string.IsNullOrWhiteSpace(roleName))
            // Don't do anything
            return Content("Role name can't be empty");

        // If we have no username...
        if (string.IsNullOrWhiteSpace(username))
            // Don't do anything
            return Content("username can't be empty");

        // Try to get the user
        var user = await mUserManager.FindByNameAsync(username);

        // If we have no user
        if (user == null)
            // Return error
            return Content("no user found");

        // Try to add the role to the user
        var result = await mUserManager.AddToRoleAsync(user, roleName);

        // If we failed...
        if (!result.Succeeded)
        // Return error
        {
            // Set the data of the error page
            ErrorController.ErrorDataModel = ErrorHelper.GetErrors(result, "the role has not been added");

            // Redirect to the error page
            return Redirect(Routes.ErrorPage);
        }

        // Return success
        return Content("role added");
    }

    #endregion
}



