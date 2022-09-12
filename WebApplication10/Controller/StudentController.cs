using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication10.Model;

namespace WebApplication10.Controller
{

    [ApiController]
    [Route("Student")]
    public class StudentController : ControllerBase
    {

        // Login , updateProfile ,  DeleteAccount

        SchoolContext _Context;
        IMapper _mapper;

        public StudentController(SchoolContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }


        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {

            return Ok("done");
        }

        [HttpGet("GetAll")]
        public ActionResult getAll()
        {
            var lst = _Context.Students.
                Include(c=>c.RegForm).
                ThenInclude(s=>s.Items).
                ThenInclude(r=>r.Subject).
                ToList();

            return Ok(lst);
        }


        [HttpPost("Register")]
        public ActionResult add(StudentRegister s)
        {

            Student st = _mapper.Map<Student>(s);

            // mapping from StudentRegister to Student
            //Student st = new Student
            //{
            //    Name = s.Name,
            //    Email = s.Email,
            //    Password = s.Password
            //};

            _Context.Students.Add(st);
            _Context.SaveChanges();

            return Ok("Done");
        }



        [HttpDelete("DeleteAccount")]
        public ActionResult Del ([FromForm]int id)
        {
            // var student = _Context.Students.Find(id);
            var student = _Context.Students.Where(c => c.Id == id).FirstOrDefault();

            if (student == null)
            {
                return BadRequest("no student with this id");
            }

            _Context.Students.Remove(student);
            _Context.SaveChanges();

            return Ok("done");

        }


        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile([FromQuery] int id , [FromForm] StudentRegister student)
        {
            var stu = _Context.Students.Find(id);

            if (stu == null)
            {
                return BadRequest("no register student with this id");
            }

            Student s = new Student()
            {
                Id = id,
                Name = student.Name ?? stu.Name,
                Email = student.Email ?? stu.Email,
                Password = student.Password ?? stu.Password
            };

            _Context.Students.Update(s);
            _Context.SaveChanges();

            return Ok(s);
        }




        [HttpPost("Login")] 
        public ActionResult Login(StudentLogin l)
        {
            var student = _Context.Students.
                Where(s => s.Email == l.Email && s.Password == l.Password).
                FirstOrDefault();

            if (student == null)
            {
                return Unauthorized("Invalid UserName or Password");
            }

            return Ok(student);
        }




        //[HttpPost("Register")]
        //public ActionResult add(string name , string email , string pass)
        //{

        //  /////  Student st = _mapper.Map<Student>(s);

        //  //  // mapping from StudentRegister to Student
        //  //  //Student st = new Student
        //  //  //{
        //  //  //    Name = s.Name,
        //  //  //    Email = s.Email,
        //  //  //    Password = s.Password
        //  //  //};

        //  //  _Context.Students.Add(st);
        //  //  _Context.SaveChanges();

        //    return Ok("Done");
        //}

    }
}
