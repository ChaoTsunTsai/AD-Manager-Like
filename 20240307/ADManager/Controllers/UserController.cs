using ADManager.Data;
using ADManager.Models;
using ADManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AD_Manager.Controllers
{
    public class UserController : Controller
    {
        private readonly ADManagerContext _dbContext;
        public UserController(ADManagerContext _dbContext)
        { 
            this._dbContext = _dbContext;
        }

        public IActionResult Admin()
        {
            return View("~/Views/User/Admin.cshtml");
        }

        public IActionResult Technician()
        {
            return View("~/Views/User/Technician.cshtml");
        }

        public IActionResult CreateSingleUser()
        {
            return View("~/Views/User/CreateSingleUser.cshtml");
        }

        [HttpPost]
        public async Task< IActionResult> AddUser(AddUserViewModel ViewModel)
        {
            var userinfo = new UserInformation
            {
                UserName = ViewModel.UserName,
                LogonName = ViewModel.LogonName,
                LogonPassword = ViewModel.LogonPassword,
                Email = ViewModel.Email,
                Rank = ViewModel.Rank,
                Status = "1"
            };

            await _dbContext.UserInformation.AddAsync(userinfo);
            await _dbContext.SaveChangesAsync();

            return View("~/Views/User/Admin.cshtml");
        }
    }
}