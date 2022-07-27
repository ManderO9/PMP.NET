namespace PMP.Web
{
    /// <summary>
    /// Contains The errors to show inside an error page
    /// </summary>
    public class ErrorDataModel
    {
        /// <summary>
        /// The list of errors
        /// </summary>
        public List<string> Errors { get; set; } = new(); 

        /// <summary>
        /// The title of the error page
        /// </summary>
        public string Title { get; set; }
    }
}
