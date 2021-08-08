using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Models;
using StudentManagementApi.Respositories;


namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepository;


        public ClassesController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _classRepository.GetClasses();
        }

        //Get: api/Classes/5/Students
        [HttpGet("{id}/Students")]
        public async Task<IEnumerable<Student>> GetStudentOfClass(int id)
        {

            return await _classRepository.GetStudentByClassId(id);
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            return await _classRepository.GetClass(id);
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Class> PutClass(int id, Class newClass)
        {

            return await _classRepository.UpdateClass(id, newClass);
        }

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class newClass)
        {
            return await _classRepository.AddClass(newClass);
        }

        // POST: api/Classes/1/Student
        [HttpPost("{id}/Student")]
        public async Task PostStudentToClass(int id, Student student)
        {
            await _classRepository.PostStudentToClass(id, student);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<Class> DeleteClass(int id)
        {
            var delClass = await _classRepository.DeleteClass(id);
            return delClass;
        }
        // DELETE: api/Classes/5/Student
        [HttpDelete("{id}/Student")]
        public async Task DeleteStudentInClass(int id, Student student)
        {
            await _classRepository.DeleteStudentInClass(id, student);
        }
        //private bool ClassExists(int id)
        //{
        //    return _context.Classes.Any(e => e.ClassId == id);
        //}
    }
}
