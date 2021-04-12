using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Logic;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentHandler _menberHandler;

        public StudentController(IStudentHandler memberHandler)
        {
            _menberHandler = memberHandler;
        }

        [HttpGet]
        [Route("/api/student/membersByGender/{gender}")]
        public List<Student> FilterStudentByGender(string gender)
        {
            return _menberHandler.FilterStudentByGender(gender);
        }
        [HttpGet]
        [Route("/api/student/FilterStudentOldest")]
        public Student FilterStudentOldest()
        {
            return _menberHandler.FilterStudentOldest();
        }
        [HttpGet]
        [Route("/api/student/ListStudentByFullNameOnly")]
        public List<string> ListStudentByFullNameOnly()
        {
            return _menberHandler.ListStudentByFullNameOnly();
        }
        [HttpGet]
        [Route("/api/student/ListStudentByYear/{year}")]
        public List<Student> ListStudentByYear(int year)
        {
            return _menberHandler.ListStudentByYear(year);
        }
        [HttpGet]
        [Route("/api/student/ListStudentGtYear/{year}")]
        public List<Student> ListStudentGtYear(int year)
        {
            return _menberHandler.ListStudentGtYear(year);
        }
        [HttpGet]
        [Route("/api/student/ListStudentLtYear/{year}")]
        public List<Student> ListStudentLtYear(int year)
        {
            return _menberHandler.ListStudentLtYear(year);
        }
        [HttpGet]
        [Route("/api/student/ListStudentBornHn/{place}")]
        public List<Student> ListStudentBornHn(string place)
        {
            return _menberHandler.ListStudentBornHn(place);
        }
        [HttpPost]
        [Route("/api/student/post")]
        public List<Student> AddMember(Student student)
        {
            return _menberHandler.AddStudent(student);
        }


    }
}