using EntityPro.Models;
using EntityPro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public DBStuTeacher _context;
        public StudentController(DBStuTeacher c)
        {
            _context = c;
        }
        [HttpPost]
        public  async ValueTask<IActionResult> CreateStudent(string name)
        {
            var student = new Student()
            {
                Name = name
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudent(int Id,string name)
        {

            var stu = await _context.Students.FirstOrDefaultAsync(x => x.Id == Id);
            stu.Name = name;
            _context.Students.Update(stu);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletedStudent(int Id)
        {
            var stu = await _context.Students.FirstOrDefaultAsync(x => x.Id == Id);
            
             _context.Students.Remove(stu);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetStudent() 
        {
            var res = await _context.Students.
                ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetStudentsAllTeachers()
        {
            var res = await _context.Students.
                Include(x => x.studentTeachers).
                ThenInclude(x=>x.Teacher).
                ToListAsync();
            return Ok(res);
        }



    }
}
