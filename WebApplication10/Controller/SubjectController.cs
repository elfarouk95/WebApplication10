using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Model;

namespace WebApplication10.Controller
{
    [ApiController]
    [Route("Subject")]
    public class SubjectController : ControllerBase
    {
        SchoolContext _Context;
        IMapper _mapper;

        public SubjectController(SchoolContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public ActionResult add(string SubjectName)
        {
            Subject s = new Subject
            {
                Name = SubjectName
            };

            _Context.Subjects.Add(s);
            _Context.SaveChanges();

         
            return Ok(s.Id);
        }
    }
}
