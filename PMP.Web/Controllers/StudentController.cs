using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMP.Data;

namespace PMP.Web
{
    /// <summary>
    /// Controlls different operations related to the student user
    /// </summary>
    [Authorize(Roles = RoleType.StudentRole)]
    public class StudentController : Controller
    {
        #region Pages

        /// <summary>
        /// Returns the main page of the student user
        /// </summary>
        /// <returns></returns>
        [Route(Routes.StudentMainPage)]
        public IActionResult MainPage()
        {
            return View();
        }

        #endregion
    }
}


