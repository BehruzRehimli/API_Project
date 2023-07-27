using System.ComponentModel.DataAnnotations;

namespace CourseAPIProject.UI.ViewModels
{
    public class GroupCreateVM
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(0, 50)]
        public int MaxStudentCount { get; set; }
    }
}
