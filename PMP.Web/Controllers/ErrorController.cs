using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PMP.Web
{
    /// <summary>
    /// Controlls errors, and displaying them to users
    /// </summary>
    public class ErrorController : Controller
    {
        #region Public Properties

        /// <summary>
        /// The model containing the information to display in the error page
        /// </summary>
        public static ErrorDataModel? ErrorDataModel { get; set; }

        #endregion

        #region Pages

        /// <summary>
        /// Returns the error page
        /// </summary>
        /// <returns></returns>
        [Route(Routes.ErrorPage)]
        public IActionResult Error()
        {
            return View(ErrorDataModel ?? new ErrorDataModel() { Title = "Default Title"});
        }

        #endregion
    }
}


