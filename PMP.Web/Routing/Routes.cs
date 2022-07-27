namespace PMP.Web
{
    /// <summary>
    /// Contains static route endpoints in our application
    /// </summary>
    public class Routes
    {
        #region Page Routes

        /// <summary>
        /// The main page to show to the user
        /// </summary>
        public const string UserMainPage = "/MainPage";

        /// <summary>
        /// The route to the login page
        /// </summary>
        public const string LoginPage = "/Login";

        /// <summary>
        /// The route to the sign in page
        /// </summary>
        public const string SigninPage = "/Signin";

        /// <summary>
        /// The route to the error page
        /// </summary>
        public const string ErrorPage = "/Error";

        /// <summary>
        /// The route to the page we gonna show when the user is not allowed to access a page/action
        /// </summary>
        public const string AccessDeniedPage = "/AccessDenied";

        #endregion

        #region API Routes

        /// <summary>
        /// The prefix of all api routes
        /// </summary>
        private const string ApiPrefix = "/API/";

        /// <summary>
        /// The route to login user using his info
        /// </summary>
        public const string APILogin = ApiPrefix + "Login";

        /// <summary>
        /// The route to signin a new user using his info
        /// </summary>
        public const string APISignin = ApiPrefix + "Signin";

        /// <summary>
        /// The route to logout from the website
        /// </summary>
        public const string Logout = "/Logout";

        /// <summary>
        /// The route to get the list of themes available in the app
        /// </summary>
        public const string GetAllThemes = ApiPrefix + "GetAllThemes";

        /// <summary>
        /// The route to get all the students
        /// </summary>
        public const string GetAllStudents = ApiPrefix + "GetAllStudents";
        
        #endregion

        #region Student Routes

        /// <summary>
        /// The prefix to all student pages
        /// </summary>
        private const string StudentPrefix = "/Student/";

        /// <summary>
        /// The route to the studen main page
        /// </summary>
        public const string StudentMainPage = StudentPrefix + "MainPage";



        #endregion

        #region Roles Routes

        /// <summary>
        /// The prefix to all roles related routes
        /// </summary>
        private const string RolesPrefix = "/Roles/";

        /// <summary>
        /// The route to create a new role
        /// </summary>
        public const string RolesCreateRole = RolesPrefix + "CreateRole";

        /// <summary>
        /// The route to add a role to a specific user
        /// </summary>
        public const string RolesAddRole = RolesPrefix + "AddRoleToUser";

        #endregion
    }
}
