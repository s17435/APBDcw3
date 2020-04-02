using System;
using cw3.Models;
using System.Collections.Generic;
namespace cw3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        void AddStudent(Student student);

        public Student GetStudentById(int id);

        public void UpdateStudent(int id, Student student);

        public void DeleteStudent(int id);
       

    }
}
