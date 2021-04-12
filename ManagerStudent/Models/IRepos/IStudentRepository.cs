using System.Collections.Generic;

namespace ManagerStudent.Models.IRepository
{
    public interface IStudentRepository
    {
        Student GetOneStudent(string id);

        List<Student> GetAllStudent();

        void CreateStudent(Student s);
    }
}