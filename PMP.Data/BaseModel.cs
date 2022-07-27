using System.ComponentModel.DataAnnotations;

namespace PMP.Data
{
    public class BaseModel
    {
        /// <summary>
        /// The unique identifier of the database table
        /// </summary>
        [Required]
        public string Id { get; set; }
    }
}
