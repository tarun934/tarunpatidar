using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Authentication;
using Project.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }
        // GET: api/<HomeController>
        [HttpGet]
        [Route("allUsers")]
        public ActionResult GetAllUsers()
        {
            var users = _unitOfWork.AppUsers.GetAll();
            return Ok(users);
        }

        // GET api/<HomeController>/5
        [HttpGet]
        [Route("user/{userId}")]
        public ActionResult GetUserById(int userId)
        {
            var user = _unitOfWork.AppUsers.GetById(userId);
            user.Courses = _unitOfWork.Courses.Find(c => c.UserId == userId).ToList();


            user.ProfileViews += 1;
            _unitOfWork.AppUsers.UpdateUser(user.UserId, user);
            _unitOfWork.Complete();
            return Ok(user);
        }

        [HttpGet]
        [Route("SearchUser/{user}")]
        public ActionResult SearchUser(string user)
        {
            var users = _unitOfWork.AppUsers.SearchUser(user);
            return Ok(users);
        }

       [HttpGet]
       [Route("allCourses")]
       public ActionResult GetAllCourses()
        {
            var Cors = _unitOfWork.Courses.GetAllCourses();
            return Ok(Cors);
        }

        [HttpGet]
        [Route("courses/{corsId}")]
        public ActionResult<Courses> GetCourses(int corsId)
        {
            Courses Cors = _unitOfWork.Courses.GetById(corsId);
            _unitOfWork.Courses.UpdateCourses(corsId, Cors);
            _unitOfWork.Complete();
            return Ok(Cors);
        }

        [HttpGet]
        [Route("SearchCourses/{Cors}")]
        public ActionResult SearchCourses(string Cors)
        {
            var cors = _unitOfWork.Courses.FindCourses(Cors);
            return Ok(cors);
        }
    }
}
