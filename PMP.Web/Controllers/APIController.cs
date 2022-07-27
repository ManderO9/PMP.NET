using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMP.Data;

namespace PMP.Web
{
    /// <summary>
    /// The controller for API calls
    /// </summary>
    public class APIController : Controller
    {
        #region Private Members 

        /// <summary>
        /// The context of the database of the application
        /// </summary>
        private ApplicationDbContext mDbContenxt;

        /// <summary>
        /// The user manager to get, delete, add and modify users
        /// </summary>
        private UserManager<AppUser> mUserManager;

        /// <summary>
        /// The role manager to get, delete, add and modify roles
        /// </summary>
        private RoleManager<AppRole> mRoleManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The context of the database of the application</param>
        public APIController(ApplicationDbContext context, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            // Set private members
            mDbContenxt = context;
            mRoleManager = roleManager;
            mUserManager = userManager;
        }

        #endregion

        #region Themes Calls

        /// <summary>
        /// Returns the list of themes that we have in the application
        /// </summary>
        /// <returns></returns>
        [Route(Routes.GetAllThemes)]
        [Authorize]
        public IActionResult GetThemes()
        {
            // Return the themes from the database
            return Ok(mDbContenxt.Themes
                //.Include(t=>t.Creator).Include(t=>t.Promo).Include(t=>t.EquipesQuiOntChoisisLeTheme)
                .ToList());
        }

        #endregion

        /// <summary>
        /// Returns the list of students
        /// </summary>
        /// <returns></returns>
        [Route(Routes.GetAllStudents)]
        [Authorize(Roles = RoleType.AdminRole)]
        public async Task<IActionResult> GetAllStudents()
        {
            // Get the list of students
            var users = await mUserManager.GetUsersInRoleAsync(RoleType.StudentRole);

            // Create the list of students
            List<StudentUser?> students = new();

            // Convert the list of users to a list of students
            users.ToList().ForEach(user =>
            {
                students.Add(user.ToUser<StudentUser>());
            });

            // Return the list of students
            return Ok(students);
        }

    }
}
