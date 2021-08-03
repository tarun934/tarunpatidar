using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Authentication;
using Project.UnitOfWorkPattern;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Authorize]
    [Route("api/{userid}/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        public CourseController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        // GET: api/<CourseController>
        [HttpGet]
        [Route("{corsId}")]
        public ActionResult<Courses> GetCourse(int userid , int corsId)
        {
            Courses Cors = _unitOfWork.Courses.GetById(corsId);
            _unitOfWork.Courses.UpdateCourses(corsId, Cors);
            _unitOfWork.Complete();
            return Cors;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult<Courses> PostCourses (int userid , Courses Cors)
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            if (!_unitOfWork.AppUsers.ValidateUser(user.Id , userid))
            {
                return Unauthorized();
            }
            Cors.UserId = userid;
            _unitOfWork.Courses.Add(Cors);
            _unitOfWork.Complete();
            return Cors;
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        [Route("{corsId}")]
        public ActionResult PutCourses (int userid, int corsId , Courses cors)
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            if (!_unitOfWork.AppUsers.ValidateUser(user.Id , userid))
            {
                return Unauthorized();
            }

            _unitOfWork.Courses.UpdateCourses(corsId, cors);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}