using EntityPro.Models;
using EntityPro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        public DBStuTeacher _context;
        public SubjectsController(DBStuTeacher c)
        {
            _context = c;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSubject(string name,string description)
        {
            var subject = new Subject()
            {
                Name = name,
                Description = description
            };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateSubject(int Id, string name,string description)
        {

            var stu = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == Id);
            stu.Name = name;
            stu.Description = description;
            _context.Subjects.Update(stu);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletedSubjects(int Id)
        {
            var stu = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == Id);

            _context.Subjects.Remove(stu);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetSubjects()
        {
            var res = await _context.Subjects.
                ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetSubjectsAllTeachers()
        {
            var res = await _context.Subjects.
                Include(x => x.Teachers).
                ToListAsync();
            return Ok(res);
        }

    }
}
