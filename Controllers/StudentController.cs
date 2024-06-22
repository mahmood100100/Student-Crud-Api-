using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudApi.Models;

namespace StudentCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> students = new List<Student>() {
          new Student() { Id = 1, age = 20 , Bio = "this is mahmoud" , Name = "mahmoud"},
          new Student() { Id = 2, age = 21 , Bio = "this is khalid" , Name = "khalid"},
          new Student() { Id = 3, age = 22 , Bio = "this is ali" , Name = "ali"}
        };
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.First(student => student.Id == id);
            Console.WriteLine(student == null);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var student = new Student()
            {
                Id = req.Id,
                Name = req.Name,
                Bio = req.Bio,
                age = req.age
            };
            students.Add(student);
            return Ok("student added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , Student req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var currentStudent = students.FirstOrDefault(student => student.Id == id);
            if(currentStudent == null)
            {
                return NotFound();
            }
            currentStudent.Name = req.Name;
            currentStudent.Bio = req.Bio;
            currentStudent.age = req.age;
            return Ok("student updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentStudent = students.FirstOrDefault(student => student.Id == id);
            if (currentStudent == null)
            {
                return NotFound();
            }
            students.Remove(currentStudent);
            return Ok("student deleted successfully");
        }

    }
}
