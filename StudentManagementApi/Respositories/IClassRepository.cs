using StudentManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementApi.Respositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClasses();
        Task<Class> GetClass(int id);
        Task<Class> AddClass(Class classObj);
        Task<Class> UpdateClass(int id, Class classObj);
        Task<Class> DeleteClass(int id);
        Task<IEnumerable<Student>> GetStudentByClassId(int id);
        Task PostStudentToClass(int id, Student student);
        Task DeleteStudentInClass(int id, Student student);
    }
}
