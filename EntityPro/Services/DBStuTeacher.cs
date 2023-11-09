using EntityPro.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityPro.Services
{
    public class DBStuTeacher:DbContext
    {
        public DBStuTeacher(DbContextOptions<DBStuTeacher> options):base(options) 
        {
            
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeachers { get; set;}
        public virtual DbSet<Subject> Subjects { get; set;}
    }
}
