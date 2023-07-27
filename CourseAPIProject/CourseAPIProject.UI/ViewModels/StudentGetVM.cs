namespace CourseAPIProject.UI.ViewModels
{
    public class StudentVM
    {
        public List<StudentGetVM> Students { get; set; }
    }
    public class StudentGetVM
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public decimal Point { get; set; }
        public StudentGetGroup Group { get; set; }

    }
    public class StudentGetGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxStudentCount { get; set; }
    }
}
