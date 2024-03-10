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

        public IActionResult CreateMultipleUser()
        {
            return View("~/Views/User/CreateMultipleUser.cshtml");
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
                Status = "1",
                Timer = DateTime.Now
            };

            await _dbContext.UserInformation.AddAsync(userinfo);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Add user success.";
            TempData["ActiveNavbarLi"] = "admin-li";
            return View("~/Views/User/Admin.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddMultipleUser(AddUserViewModel ViewModel)
        {
            var userinfo = new UserInformation
            {
                UserName = ViewModel.UserName,
                LogonName = ViewModel.LogonName,
                LogonPassword = ViewModel.LogonPassword,
                Email = ViewModel.Email,
                Rank = ViewModel.Rank,
                Status = "1",
                Timer = DateTime.Now
            };

            await _dbContext.UserInformation.AddAsync(userinfo);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Add user success.";

            ModelState.Clear();
                        
            return View("~/Views/User/CreateMultipleUser.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userinfo = await _dbContext.UserInformation.ToListAsync();

            //return View("~/Views/User/List.cshtml", userinfo);
            return View(userinfo);
        }

        [HttpGet]
        public async Task<IActionResult> EditSingleUser(Guid id)
        {
            var userinfo = await _dbContext.UserInformation.FindAsync(id);

            return View(userinfo);
        }

        [HttpPost]
        public async Task<IActionResult> EditSingleUser(UserInformation viewModel)
        {
            var userinfo = await _dbContext.UserInformation.FindAsync(viewModel.Id);

            if(userinfo is not null)
            {
                userinfo.UserName = viewModel.UserName;
                userinfo.LogonName = viewModel.LogonName;
                userinfo.Email = viewModel.Email;
                userinfo.Rank = viewModel.Rank;
                userinfo.LogonPassword = viewModel.LogonPassword;

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "User");
        }       

        [HttpPost]
        public async Task<IActionResult> DeleteSingleUser(UserInformation viewModel)
        {
            var userinfo = await _dbContext.UserInformation.FindAsync(viewModel.Id);

            if (userinfo is not null)
            {
                _dbContext.UserInformation.Remove(userinfo);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "User");
        }

        [HttpGet]
        public async Task<IActionResult> ListForMultipleUser()
        {
            var userinfo = await _dbContext.UserInformation.ToListAsync();

            //return View("~/Views/User/List.cshtml", userinfo);
            return View("~/Views/User/ListForMultipleUser.cshtml", userinfo);
        }

        [HttpGet]
        public async Task<IActionResult> EditMultipleUser()
        {
            var users = await _dbContext.UserInformation.ToListAsync();
            return View("~/Views/User/EditMultipleUser.cshtml", users);
        }

        /*[HttpPost]
        public async Task<IActionResult> EditMultipleUser(List<UserInformation> users)
        {
            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    var userinfo = await _dbContext.UserInformation.FindAsync(user.Id);
                    if (userinfo is not null)
                    {                        
                        userinfo.UserName = user.UserName;
                        userinfo.Email = user.Email;
                        userinfo.Rank = user.Rank;
                        userinfo.LogonPassword = user.LogonPassword;
                        // 根據需求更新其他字段
                    }
                }
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListForMultipleUser", "User");
        }*/

        [HttpPost]
        public async Task<IActionResult> EditMultipleUser(List<Guid> selectedUsers, [FromForm] List<UserInformation> users)
        {
            // 篩選出被選中的用戶
            var selectedUserInfo = users.Where(u => selectedUsers.Contains(u.Id)).ToList();

            try
            {
                if (selectedUserInfo.Count > 0)
                {
                    foreach (var user in selectedUserInfo)
                    {
                        var userinfo = await _dbContext.UserInformation.FindAsync(user.Id);
                        if (userinfo != null)
                        {
                            userinfo.UserName = user.UserName;
                            userinfo.Email = user.Email;
                            userinfo.Rank = user.Rank;
                            userinfo.LogonPassword = user.LogonPassword;
                            // 根據需求更新其他字段
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "用戶資訊更新成功！";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"更新失敗: {ex.Message}";
            }

            return RedirectToAction("ListForMultipleUser", "User");
        }
    }
}