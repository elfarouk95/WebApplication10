using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using WebApplication10.Model;

namespace WebApplication10.Controller
{

    [ApiController]
    [Route("Student")]
    public class StudentController : ControllerBase
    {

        // Login , UpdateProfile ,  DeleteAccount

        SchoolContext _Context;
        IMapper _mapper;

        public StudentController(SchoolContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public ActionResult getAll()
        {
            var lst = _Context.Students.
                Include(c => c.RegForm).
                ThenInclude(s => s.Items).
                ThenInclude(r => r.Subject).
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


        [HttpPost("Login")]
        public ActionResult Login(StudentLogin log)
        {
            var student = _Context.Students.
                Where(s => s.Email == log.Email && s.Password == log.Password)
                .FirstOrDefault();

            if (student == null)
            {
                return Unauthorized("Invalid UserName or Password");
            }

            return Ok(student);

        }

        [HttpDelete("DeleteAccount")]
        public ActionResult DeleteAccount([FromForm] int Id)
        {

            // var student = _Context.Students.Find(Id);
            var student = _Context.Students.Where(s => s.Id == Id).FirstOrDefault();

            if (student == null)
            {
                return BadRequest("there is no student with this id");
            }

            _Context.Students.Remove(student);
            _Context.SaveChanges();

            return Ok("done");
        }

        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile([FromQuery] int Id, [FromBody] StudentRegister reg)
        {

            var st = _Context.Students.AsNoTracking().Where(c => c.Id == Id).FirstOrDefault();


            if (st == null)
            {
                return BadRequest("aaa");
            }

            Student s = new Student
            {
                Id = Id,
                Name = reg.Name ?? st.Name,
                Email = reg.Email ?? st.Email,
                Password = reg.Password ?? st.Password,
                ImagePath = reg.ImagePath,
                RegFormId = st.RegFormId
            };

            _Context.Students.Update(s);
            _Context.SaveChanges();

            return Ok("done");
        }


        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filePath = fullPath + "/" + name;

            var stream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(stream);

            return Ok("Images/" + name);

        }



        //[HttpPost("Register")]
        //public ActionResult add(string name, string email, string pass)
        //{

        //    // Student st = _mapper.Map<Student>(s);

        //    /// mapping from StudentRegister to Student
        //   Student st = new Student
        //   {
        //       Name = name,
        //       Email = email,
        //       Password =pass
        //   };

        //    _Context.Students.Add(st);
        //    _Context.SaveChanges();

        //    return Ok("Done");
        //}

    }
}
