using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PMP.Web
{
    /// <summary>
    /// Helpers to display errors to the user
    /// </summary>
    public class ErrorHelper
    {
        /// <summary>
        /// Returns an error to the user,displays the error message and the list of <see cref="IdentityError"/> if any
        /// </summary>
        /// <param name="identityResult">The result of the operation containing the errors</param>
        /// <param name="message">The message to show before the errors</param>
        /// <returns>An <see cref="IActionResult"/></returns>
        public static ErrorDataModel GetErrors(IdentityResult? identityResult = null, string message = "")
        {
            // Create the error data model
            var model = new ErrorDataModel();

            // Set the title of the error
            model.Title = message;

            // For each error in the result...
            identityResult?.Errors.ToList().ForEach(error =>
            {
                // Add the error description to the list of errors
                model.Errors.Add(error.Description);
            });

            // Return the model
            return model;
        }
    }
}
