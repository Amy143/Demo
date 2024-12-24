using EFCoreDemo.Data;
using EFCoreDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApplicationDbContext _db;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        public List<StudentEntity> GetAllStudents()
        {
            _logger.LogInformation("Fetching all students list");
            return _db.StudentsRegister.ToList();
        }

        [HttpGet("GetStudentsById")]
        public ActionResult<StudentEntity> GetStudentDeatils(Int32 id) 
        {
            if (id == 0)
            {
                _logger.LogError("Id wasn't passed");
                return BadRequest();
            }
            var StudentDetails = _db.StudentsRegister.FirstOrDefault(x => x.id == id);

            if (StudentDetails == null)
            {
                return NotFound();
            }

            return StudentDetails;
        }

        [HttpPost("AddStudentDetails")]
        public ActionResult<StudentEntity> AddStudent([FromBody] StudentEntity studentDetails)
        {
          if (!ModelState.IsValid)
          {
                return BadRequest(ModelState);
          }

          _db.StudentsRegister.Add(studentDetails);
          _db.SaveChanges();

            return Ok(studentDetails);

        }

        [HttpPost("UpdateStudentDetails")]
        public ActionResult<StudentEntity> UpdateStudent(Int32 id, [FromBody] StudentEntity studentDetails)
        {
            if (studentDetails == null)
            {
                return BadRequest(studentDetails);
            }

            var StudentDetails = _db.StudentsRegister.FirstOrDefault(x => x.id == id);

            if (StudentDetails == null)
            {
                return NotFound();
            }

            StudentDetails.Name = studentDetails.Name;
            StudentDetails.Email = studentDetails.Email;
            StudentDetails.Age = studentDetails.Age;
            StudentDetails.Standard = studentDetails.Standard;


            _db.SaveChanges();

            return Ok(studentDetails);

        }

        [HttpPut("DeleteStudent")]
        public ActionResult<StudentEntity> Delete(Int32 id)
        {
            
            var StudentDetails = _db.StudentsRegister.FirstOrDefault(x => x.id == id);

            if (StudentDetails == null)
            {
                return NotFound();
            }
            _db.Remove(StudentDetails);
            
            _db.SaveChanges();

            return NoContent();

        }

        //[HttpGet("GetAllStudentsName")]
        //public string GetAllStudentsName()
        //{
        //    return "Hello Student";
        //}

    }
}
