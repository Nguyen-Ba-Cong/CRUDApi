using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementApi.Respositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentDBContext _context;
        public ClassRepository(StudentDBContext context)
        {
            this._context = context;
        }
        public async Task<Class> AddClass(Class newClass)
        {
            try
            {

                if (!_context.Classes.Contains(newClass))
                {
                    _context.Classes.Add(newClass);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new NotImplementedException("Class Existed");
                }
                return newClass;

            }
            catch (Exception e)
            {
                throw new NotImplementedException("Add fail: " + e.Message);
            }
        }

        public async Task<Class> DeleteClass(int id)
        {
            Class delClass = await GetClass(id);
            try
            {
                if (delClass == null)
                {
                    return null;
                }
                var classEnrolments = await _context.ClassEnrolments.Where(x => x.ClassId == id).ToListAsync();
                _context.ClassEnrolments.RemoveRange(classEnrolments);
                _context.Classes.Remove(delClass);
                await _context.SaveChangesAsync();
                return delClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return null;

        }

        public async Task DeleteStudentInClass(int id, Student student)
        {
            try
            {
                var studentCheck = await _context.ClassEnrolments
                    .FirstOrDefaultAsync(ce => ce.ClassId == id && ce.StudentId == student.StudentId);
                if (studentCheck == null)
                {
                    throw new NotImplementedException("Student not exist in class");
                }
                else
                {
                    _context.ClassEnrolments.Remove(studentCheck);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Class> GetClass(int id)
        {
            try
            {
                return await _context.Classes.Include(c => c.ClassEnrolments).FirstOrDefaultAsync(c => c.ClassId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            try
            {
                return await _context.Classes.Include(c => c.ClassEnrolments).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetStudentByClassId(int id)
        {
            try
            {
                var classEnrolments = await _context.ClassEnrolments
                    .Include(ce => ce.Student)
                    .Where(ce => ce.ClassId == id)
                    .ToListAsync();
                List<Student> listStudent = new List<Student>();
                foreach (var s in classEnrolments)
                {
                    listStudent.Add(s.Student);
                }
                return listStudent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task PostStudentToClass(int id, Student student)
        {
            try
            {
                var studentPost = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
                if (studentPost == null)
                {
                    throw new NotImplementedException("Student Not Exist");
                }
                else
                {
                    var checkStudent = await _context.ClassEnrolments
                        .SingleOrDefaultAsync(ce => ce.ClassId == id && ce.StudentId == student.StudentId);
                    if (checkStudent != null)
                    {
                        throw new NotImplementedException("Student Already  Exist In Class");
                    }
                    else
                    {
                        ClassEnrolment classEnrolment = new ClassEnrolment();
                        classEnrolment.ClassId = id;
                        classEnrolment.StudentId = student.StudentId;
                        _context.ClassEnrolments.Add(classEnrolment);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Add Fail: " + e.Message);
            }
        }

        public async Task<Class> UpdateClass(int id, Class classObj)
        {
            if (id != classObj.ClassId)
            {
                return null;
            }
            try
            {
                var newClass = await GetClass(classObj.ClassId);
                newClass.Name = classObj.Name;
                await _context.SaveChangesAsync();
                return newClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return null;

        }
    }
}
