using System.ComponentModel.DataAnnotations;

namespace CourseAPIProject.UI.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MaxLength(100)]    
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
