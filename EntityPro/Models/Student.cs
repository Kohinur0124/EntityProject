namespace EntityPro.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<StudentTeacher> studentTeachers { get; set; }
    }
}
