using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using PMP.Data;

namespace PMP.Web;

/// <summary>
/// Controlls different operations related to account login, signin, creation, deletion...
/// </summary>
public class AccountController : Controller
{
    #region Private Members

    /// <summary>
    /// The application db context
    /// </summary>
    private ApplicationDbContext mDbContext;

    /// <summary>
    /// The signin manager to sign users in
    /// </summary>
    private SignInManager<AppUser> mSignInManager;

    /// <summary>
    /// The user manager to create, delete and get users and manage roles
    /// </summary>
    private UserManager<AppUser> mUserManager;

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="dbContext">The app db context</param>
    /// <param name="signInManager">The sign in manager passed in from DI</param>
    /// <param name="userManager">The user manager</param>
    public AccountController(ApplicationDbContext dbContext, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        // Set local variables
        mDbContext = dbContext;
        mSignInManager = signInManager;
        mUserManager = userManager;
    }

    #endregion

    #region Account Pages

    /// <summary>
    /// The default login action on redirect, returns the login page
    /// </summary>
    /// <returns></returns>
    [Route(Routes.LoginPage)]
    public IActionResult Login()
    {
        // Return the login page
        return View();
    }

    /// <summary>
    /// Returns the signin page
    /// </summary>
    /// <returns></returns>
    [Route(Routes.SigninPage)]
    public IActionResult Signin()
    {
        // Return the signin page
        return View();
    }

    /// <summary>
    /// The main page of the user
    /// </summary>
    /// <returns></returns>
    [Route(Routes.UserMainPage)]
    [Authorize]
    public IActionResult MainPage()
    {
        return View(new UserMainPageDataModel() { Name = HttpContext.User.Identity.Name});
    }

    /// <summary>
    /// The action that will get called when accessing a page is not allowed to this user
    /// </summary>
    /// <returns></returns>
    [Route(Routes.AccessDeniedPage)]
    public IActionResult AccessDenied()
    {
        return View();
    }


    #endregion

    #region API Calls

    /// <summary>
    /// Logs a user in
    /// </summary>
    /// <param name="username">The username of the user</param>
    /// <param name="password">The password of the user</param>
    /// <returns></returns>
    [Route(Routes.APILogin)]
    public async Task<IActionResult> LoginWithCredentials(string username, string password)
    {
        // If we have no username...
        if (string.IsNullOrEmpty(username))
            // Return an error to the user
            return Content("No username has been provided");

        // If we have no password...
        if (string.IsNullOrEmpty(password))
            // Return an error to the user
            return Content("No password has been provided");

        // Try loggin in the user
        var result = await mSignInManager.PasswordSignInAsync(username, password, true, true);

        // If succeeded
        if (result.Succeeded)
            // Redirect the user to his main page
            return Redirect(Routes.UserMainPage);

        // Otherwise, return an error
        return Content("failed to log in");
    }

    /// <summary>
    /// Singns the user in, and creates a new user in the database
    /// </summary>
    /// <param name="username">The user's username</param>
    /// <param name="email">The user's email</param>
    /// <param name="password">The user's password</param>
    /// <returns></returns>
    [Route(Routes.APISignin)]
    public async Task<IActionResult> SignInWithCredentials(string username, string email, string password)
    {
        // If we have no username...
        if (string.IsNullOrEmpty(username))
            // Return an error to the user
            return Content("No username has been provided");

        // If we have no password...
        if (string.IsNullOrEmpty(password))
            // Return an error to the user
            return Content("No password has been provided");

        // If we have no email...
        if (string.IsNullOrEmpty(email))
            // Return an error to the user
            return Content("No email has been provided");

        // Try create the user with the passed in info
        var result = await mUserManager.CreateAsync(new AppUser()
        {
            Email = email,
            UserName = username,

        }, password);

        // If the user was created
        if (result.Succeeded)
        {
            // Return redirect to user's main page
            return Redirect(Routes.UserMainPage);
        }

        // If not successful...

        // Return the errors to the user
        return View("/Error/Error", ErrorHelper.GetErrors(result, "failed to sign in"));
    }

    /// <summary>
    /// Signs the user out of our website
    /// </summary>
    /// <returns></returns>
    [Route(Routes.Logout)]
    public async Task<IActionResult> Logout()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

        // Go back to main page
        return Redirect("/");

    }

    #endregion

}



