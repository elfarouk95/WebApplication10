using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication10.Model;

namespace WebApplication10.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        SchoolContext _context;
        IMapper _mapper;

        public StudentController(SchoolContext schoolContext, IMapper mapper)
        {
            _context = schoolContext;
            _mapper = mapper;
        }

        [HttpGet("GetALL")]
        public ActionResult getAll()
        {
            var lst = _context.Students.
                Include(c => c.RegForm).
                ThenInclude(c=>c.Items).ThenInclude(c=>c.Subject)
                .ToList();
            return Ok(lst);
        }


        [HttpPost("AddStudent")]
        public ActionResult Add(StudentRegister s)
        {

            Student st = _mapper.Map<Student>(s);
/*
            Student st = new Student
            {
                Name = s.Name,
                Email = s.Email,
                Password = s.Password
            };
*/
            _context.Students.Add(st);
            _context.SaveChanges();

            return Ok(s);
        }
    }
}
