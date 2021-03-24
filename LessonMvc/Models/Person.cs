using System;
namespace LessonMvc.Models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int phoneNumber { get; set; }
        public string birthPlace { get; set; }
        public Boolean isGraduated { get; set; }

        public Person(string firstName, string lastName, string gender, DateTime dateOfBirth, int phoneNumber, string birthPlace, Boolean isGraduated)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.birthPlace = birthPlace;
            this.isGraduated = isGraduated;
        }
    }
}