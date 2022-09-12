using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication10.Model;

namespace WebApplication10.Controller
{

    [ApiController]
    [Route("RegForm")]
    public class RegFormController : ControllerBase
    {
        SchoolContext _Context;
        IMapper _mapper;

        public RegFormController(SchoolContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        [HttpPost("AddForm")]
        public ActionResult RegisterSubject(RegData data)
        {

            RegForm form = new RegForm();
            form.StudentId = data.StudentId;
            form.Date = DateTime.Now;

            _Context.RegForms.Add(form);
            _Context.SaveChanges();

            foreach (var subId in data.SubjectIds)
            {
                RegFormItem item = new RegFormItem();
                item.SubjectId = subId;
                item.RegFormId = form.Id;

                _Context.RegFormItems.Add(item);
            }

            _Context.SaveChanges();


            return Ok("done");

        }

    }
}
