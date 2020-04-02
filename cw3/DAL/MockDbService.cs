﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw3.Models;
using Microsoft.AspNetCore.Builder;

namespace cw3.DAL
{
    public class MockDbService : IDbService
    {

        private static List<Student> _students;

        static MockDbService()
        {
            _students = new List<Student> {
                new Student { IdStudent = 1, FirstName="Jan", LastName = "Kowalski"},
                new Student { IdStudent = 2, FirstName="Anna", LastName = "Malewska"},
                new Student { IdStudent = 3, FirstName="Krzysztof", LastName = "Jarzębina"}



            };
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            Student exStudent = GetStudentById(id);
            _students.Remove(exStudent);
        }

        public Student GetStudentById(int id)
        {
            Student result = _students.Find(x => x.IdStudent == id);

            return result;

        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void UpdateStudent(int id, Student student)
        {
            Student existingStudent = GetStudentById(id);
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.IndexNumber = student.IndexNumber;

        }
    }
}
