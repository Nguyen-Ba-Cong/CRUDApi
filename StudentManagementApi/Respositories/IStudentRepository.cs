using StudentManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementApi.Respositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudent(int id);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> DeleteStudent(int id);

        Task<IEnumerable<Class>> GetClassByStudentId(int id);

    }
}
