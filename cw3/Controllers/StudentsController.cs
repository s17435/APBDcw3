using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw3.DAL;
using cw3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private IDbService _dbService;



        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetStudent(string orderBy = "Nazwisko")
        {

            return Ok(_dbService.GetStudents());
        }



        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {

            Student student = _dbService.GetStudentById(id);

            if (student is null)
            {
                return NotFound("Nie ma ucznia o takim id");
            } else
            {
                return Ok(student);
            }



           


            //if (id == 1)
            //{
            //    return Ok("Kowalski");

            //}
            //else if (id == 2)
            //{
            //    return Ok("Malewski");
            //}
            //return NotFound("Nie znaleziono studenta");
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            _dbService.AddStudent(student);


            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student tmpstudent)
        {

            Student existingstudent = _dbService.GetStudentById(id);

            if (existingstudent is null)
            {
                return NotFound("Nie ma ucznia o takim id");
            }
            else
            {

                _dbService.UpdateStudent(id, tmpstudent);

                return Ok("Aktualizacja dokończona");
            }


       
        }



        //[HttpPut("{id}")]
        //public IActionResult UpdateStudent(int id)
        //{

        //    return Ok("Aktualizacja dokończona");
        //}




        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student existingstudent = _dbService.GetStudentById(id);

            if (existingstudent is null)
            {
                return NotFound("Nie ma ucznia o takim id");
            } else
            {
                _dbService.DeleteStudent(id);

                return Ok("Usuwanie ukończone");
            }

            
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    return Ok("Usuwanie ukończone");
        //}


    }
}
