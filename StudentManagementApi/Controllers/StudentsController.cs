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
    public class StudentsController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;


        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }
        //Get: api/Classes/5/Students
        [HttpGet("{id}/Classes")]
        public async Task<IEnumerable<Class>> GetClassOfStudent(int id)
        {

            return await _studentRepository.GetClassByStudentId(id);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await _studentRepository.GetStudent(id);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Student> PutStudent(int id, Student student)
        {
            return await _studentRepository.UpdateStudent(id, student);
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Student> PostStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<Student> DeleteStudent(int id)
        {
            var delStudent = await _studentRepository.DeleteStudent(id);
            return delStudent;
        }

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.StudentId == id);
        //}
    }
}
