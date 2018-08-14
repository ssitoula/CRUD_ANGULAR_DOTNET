using CRUD_Angular_Asp.Services;
using CRUD_Angular_Asp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_Angular_Asp.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentServices _studentservices;
        public StudentController(IStudentServices studentservices)
        {
            _studentservices = studentservices;
        }

        [HttpGet]
        [Route("api/student/getstudentdetails")]
        public IHttpActionResult GetStudentList()
        {
          //  var data = "sanam";
         var data = _studentservices.ListStudent();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpPost]
        [Route("api/student/addstudent")]
        public IHttpActionResult AddStudent([FromBody]StudentViewModel m)
        {
            var result = _studentservices.AddStudent(m);
            return Ok(result);
        }


        [HttpGet]
        [Route("api/student/GetStudentById")]
        public IHttpActionResult GetStudentById(int id)
        {
            var result = _studentservices.GetStudentById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/student/updatestudent")]
        public IHttpActionResult EditStudent(StudentViewModel model)
        {
            var result = _studentservices.EditStudent(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/student/DeleteStudent")]
        public IHttpActionResult DeleteStudent([FromBody] int? id)
        {
            var data = _studentservices.DeleteStudent(id ?? 0);
            return Ok(data);
        }


    }
}
