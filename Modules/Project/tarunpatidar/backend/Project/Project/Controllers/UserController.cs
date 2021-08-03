using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.Authentication;
using Project.UnitOfWorkPattern;
using System;
using System.Data;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        //[HttpGet]
        //public IActionResult GetCurrentUserId()
        //{
        //    var user = userManager.Users.First(x => x.UserName == User.Identity.Name);

        //    return Ok(user);
        //}

        // GET: api/<UserController>
        [HttpGet]
        [Route("current")]
        public ActionResult GetCurrentUser()
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            var appuser = _unitOfWork.AppUsers.Find(u => u.ApplicationUserId == user.Id).First();
            appuser.Courses = _unitOfWork.Courses.Find(c => c.UserId == appuser.UserId).ToList();

            return Ok(appuser);
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            if (!_unitOfWork.AppUsers.ValidateUser(user.Id , id))
            {
                return Unauthorized();
            }
            AppUser myuser = _unitOfWork.AppUsers.GetById(id);
            myuser.Courses = _unitOfWork.Courses.Find(c => c.UserId == id).ToList();

            return myuser;
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult<AppUser> PostUser(int id , AppUser user)
        {
            var u = userManager.Users.AsNoTracking().First(x => x.UserName == User.Identity.Name);
            if (!_unitOfWork.AppUsers.ValidateUser(u.Id , id))
            {
                return Unauthorized();
            }
            var appUser = _unitOfWork.AppUsers.Find(a => a.ApplicationUserId == u.Id).First();
            appUser.FullName = user.FullName;
            appUser.Title = user.Title;
            appUser.Location = user.Location;
            appUser.GitHub = user.GitHub;
            appUser.Twitter = user.Twitter;
            appUser.AboutUser = user.AboutUser;
            _unitOfWork.AppUsers.UpdateUser(id, appUser);
            _unitOfWork.Complete();
            return user;
        }
    }
}
