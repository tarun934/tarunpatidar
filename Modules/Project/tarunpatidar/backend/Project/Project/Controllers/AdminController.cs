using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        public AdminController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public ActionResult<List<AppUser>> GetAllUser()
        {
            var users = _unitOfWork.AppUsers.GetAll().ToList();
            return users;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUserId(int id)
        {
            var user = _unitOfWork.AppUsers.GetById(id);
            return user;
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public ActionResult<AppUser> DeleteUser(int id)
        {
            var user = _unitOfWork.AppUsers.GetById(id);
            _unitOfWork.AppUsers.Remove(user);
            _unitOfWork.Complete();
            return user;
        }
    }
}
