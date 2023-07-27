using System.ComponentModel.DataAnnotations;

namespace CourseAPIProject.UI.ViewModels
{
    public class StudentEditVM
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Range(0, 50)]
        public int Age { get; set; }
        [Range(0, 100)]
        public decimal Point { get; set; }
        [Range(0, int.MaxValue)]
        public int GroupId { get; set; }

    }
}
