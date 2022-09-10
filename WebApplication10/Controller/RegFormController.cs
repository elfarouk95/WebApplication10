using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication10.Model;

namespace WebApplication10.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegFormController : ControllerBase
    {
        SchoolContext _context;
        IMapper _mapper;

        public RegFormController(SchoolContext schoolContext, IMapper mapper)
        {
            _context = schoolContext;
            _mapper = mapper;
        }


        [HttpPost("Add")]
        public ActionResult add(RegFormDTO r)
        {

            RegForm obj = new RegForm();

            obj.StudentId = r.StudentID;
            obj.Date = DateTime.Now;

            _context.RegForms.Add(obj);
            _context.SaveChanges();



            obj.Items = new List<RegFormItem>();


            for (int i = 0; i < r.SubjectsIds.Count; i++)
            {
                RegFormItem f = new RegFormItem();
                f.SubjectId = r.SubjectsIds[i];
                f.RegFormId = obj.Id;

                _context.RegFormItems.Add(f);
            }

            _context.SaveChanges();

            return Ok("done");

        }

    }
}
