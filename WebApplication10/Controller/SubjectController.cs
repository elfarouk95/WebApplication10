using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Model;

namespace WebApplication10.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        SchoolContext _context;
        IMapper _mapper;

        public SubjectController(SchoolContext schoolContext, IMapper mapper)
        {
            _context = schoolContext;
            _mapper = mapper;
        }

        [HttpPost("AddSubject")]
        public ActionResult Add(string SubjectName)
        {

            Subject s = new Subject
            {
                Name = SubjectName
            };
  
            _context.Subjects.Add(s);
            _context.SaveChanges();

            return Ok(s);
        }
    }

}
