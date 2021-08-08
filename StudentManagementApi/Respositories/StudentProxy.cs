using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementApi.Respositories
{
    public class StudentProxy : IStudentRepository
    {
        private readonly StudentDBContext _context;
        private readonly StudentRepository _studentRepository;
        public StudentProxy(StudentDBContext context, StudentRepository studentRepository)
        {
            this._context = context;
            _studentRepository = studentRepository;

        }
        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                if (!_context.Students.Contains(student))
                {
                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();

                }
                return student;

            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));

            }
            return null;

        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student delStudent = await GetStudent(id);
            try
            {
                if (delStudent == null)
                {
                    return null;
                }
                var classEnrolments = await _context.ClassEnrolments.Where(x => x.StudentId == id).ToListAsync();
                _context.ClassEnrolments.RemoveRange(classEnrolments);
                _context.Students.Remove(delStudent);
                await _context.SaveChangesAsync();
                return delStudent;
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                return null;

            }
        }

        public async Task<IEnumerable<Class>> GetClassByStudentId(int id)
        {
            try
            {
                var classEnrolments = await _context.ClassEnrolments
                    .Include(ce => ce.Class)
                    .Where(ce => ce.StudentId == id)
                    .ToListAsync();
                List<Class> listClass = new List<Class>();
                foreach (var c in classEnrolments)
                {
                    listClass.Add(c.Class);
                }
                return listClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                return null;
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            try
            {
                return await _context.Students.Include(s => s.ClassEnrolments).FirstOrDefaultAsync(s => s.StudentId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                return null;
            }

        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await _context.Students.Include(s => s.ClassEnrolments).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                return null;
            }
        }

        public async Task<Student> UpdateStudent(int id, Student studentObj)
        {
            if (id != studentObj.StudentId)
            {
                var newStudent = await GetStudent(studentObj.StudentId);
                newStudent.Name = studentObj.Name;
                newStudent.Gender = studentObj.Gender;
                return newStudent;
            }
            return await _studentRepository.UpdateStudent(id, studentObj);


        }
    }
}
