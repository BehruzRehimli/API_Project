namespace CourseAPIProject.UI.ViewModels
{
    public class GroupVM
    {
        public List<GroupVMItem> Groups { get; set; }
    }

    public class GroupVMItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  MaxStudentCount { get; set; }
        public int StudentsCount { get; set; }
    }
}
