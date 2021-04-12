using System.Collections.Generic;
using ManagerStudent.Models.IRepository;
using System.Linq;

namespace ManagerStudent.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ManagerStudentContext _dbContext;

        public  StudentRepository(ManagerStudentContext dbContext){
            _dbContext = dbContext;
        }
        
        public List<Student> GetAllStudent()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetOneStudent(string id)
        {
            return _dbContext.Students.SingleOrDefault(s => s.Id == id);
        }

        public void CreateStudent(Student s){
            _dbContext.Students.Add(s);
            _dbContext.SaveChanges();
        }
    }
}