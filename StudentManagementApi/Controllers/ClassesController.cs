using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public ClassesController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        //Get: api/Classes/5/Students
        [HttpGet("{id}/Students")]
        public async Task<ActionResult<Class>> GetStudentOfClass(int id)
        {
            //List<Student> students = new List<Student>();
            //var @class = await _context.Classes
            //                        .Include(c => c.ClassEnrolments)
            //                        .ThenInclude(cs => cs.Student)
            //                        .Where(c => c.ClassId == id)
            //                        .FirstOrDefaultAsync();
            //foreach(var st in @class.ClassEnrolments)
            //{
            //    students.Add(st.Student);
            //}


            //if (@class == null)
            //{
            //    return NotFound();
            //}
            //return Ok(students);
            var listStudentClass = await _context.ClassEnrolments
                .Include(sc => sc.Student)
                .Where(sc => sc.ClassId == id)
                .ToListAsync();
            List<Student> listStudent = new List<Student>();
            foreach (var s in listStudentClass)
            {
                listStudent.Add(s.Student);
            }

            return Ok(listStudent);
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            var @class = await _context.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class @class)
        {
            if (id != @class.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.ClassId }, @class);
        }

        // POST: api/Classes/1/Student
        [HttpPost("{id}/Student")]
        public async Task<ActionResult<Class>> PostStudentToClass(int id, Student student)
        {
            var stu = await _context.Students.SingleOrDefaultAsync(s => s.StudentId == student.StudentId);
            if (stu == null)
            {
                return NotFound("Sinh Vien Chua Ton Tai");
            }
            else
            {
                ClassEnrolment classEnrolment = new ClassEnrolment();
                classEnrolment.ClassId = id;
                classEnrolment.StudentId = student.StudentId;
                _context.ClassEnrolments.Add(classEnrolment);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Classes/5/Student
        [HttpDelete("{id}/Student")]
        public async Task<IActionResult> DeleteStudentInClass(int id, Student student)
        {
            var stu = await _context.Students.SingleOrDefaultAsync(s => s.StudentId == student.StudentId);
            if (stu == null)
            {
                return NotFound("Sinh Vien Chua Ton Tai");
            }
            else
            {
                var classEnrolment = await _context.ClassEnrolments
                    .Where(ce => ce.StudentId == student.StudentId && ce.ClassId == id)
                    .FirstOrDefaultAsync();
                if (classEnrolment == null)
                {
                    return NotFound("Khong Ton Tai Sinh Vien Nay Trong Lop");
                }
                else
                {
                    _context.ClassEnrolments.Remove(classEnrolment);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }
        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.ClassId == id);
        }
    }
}
