namespace EntityPro.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }
        public ICollection<StudentTeacher> studentTeachers { get; set; }
    }
}
