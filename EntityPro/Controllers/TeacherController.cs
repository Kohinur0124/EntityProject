using EntityPro.Models;
using EntityPro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public DBStuTeacher _context;
        public TeacherController(DBStuTeacher c)
        {
            _context = c;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacher(string name,int subjectId)
        {
            var teacher = new Teacher()
            {
                Name = name,
                SubjectId = subjectId
            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacher(int Id, string name,int subjectId)
        {

            var stu = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
            stu.Name = name;
            stu.SubjectId = subjectId;
            _context.Teachers.Update(stu);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletedTeacher(int Id)
        {
            var tea = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);

            _context.Teachers.Remove(tea);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetTeacher()
        {
            var res = await _context.Teachers.
                ToListAsync();
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetTeachersAllStudents()
        {
            var res = await _context.Teachers.
                Include(x=>x.studentTeachers).
                ThenInclude(x=>x.Student).
                ToListAsync();
            return Ok(res);
        }


        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentTeacher(int studentId,int teacherId)
        {
            var studentteacher = new StudentTeacher()
            {
                StudentId = studentId,
                TeacherId = teacherId,
            };
            await _context.StudentTeachers.AddAsync(studentteacher);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentTeacher(int Id, int studentId, int teacherId)
        {

            var st = await _context.StudentTeachers.FirstOrDefaultAsync(x => x.Id == Id);
            st.StudentId = studentId;
            st.TeacherId = teacherId;
            _context.StudentTeachers.Update(st);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletedStudenTeachert(int Id)
        {
            var stu = await _context.StudentTeachers.FirstOrDefaultAsync(x => x.Id == Id);

            _context.StudentTeachers.Remove(stu);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

    }
}
