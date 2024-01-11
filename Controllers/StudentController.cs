using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication1.Model;
using WebApplication1.Model.Domain;
using WebApplication1.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext schoolDbContext;

        public StudentController(SchoolDbContext schoolDbContext)
        {
            this.schoolDbContext = schoolDbContext;
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto request)
        {
            
            var student = new Student
            {
                FirstName = request.firstName,
                LastName = request.lastName,
                Email = request.email,
                DateOfBirth = request.dateOfBirth,
                ParentName = request.parentName,
                ParentPhoneNumber = request.parentPhoneNumber,
                Address = request.address,
            };

            await schoolDbContext.Students.AddAsync(student);
            await schoolDbContext.SaveChangesAsync();


            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> getStudent()
        {
            try
            {
                var student = await schoolDbContext.Students.ToListAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            try
            {
                var student = await schoolDbContext.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound("student not found");
                }
                

                schoolDbContext.Students.Remove(student);
                await schoolDbContext.SaveChangesAsync();

                return Ok(student);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentRequestDto stu)
        {
            var student = await schoolDbContext.Students.FirstOrDefaultAsync(a => a.StudentId == id);
            if (student != null)
            {
                student.FirstName = stu.firstName;
                student.LastName = stu.lastName;
                student.Email = stu.email;  
                student.Address = stu.address;
                student.ParentPhoneNumber = stu.parentPhoneNumber;
                student.ParentName = stu.parentName;
                student.DateOfBirth = stu.dateOfBirth;

                await schoolDbContext.SaveChangesAsync();

                return Ok(student);
            }
            else
            {
                return NotFound("Student Not Found");
            }
        }
    }
}
