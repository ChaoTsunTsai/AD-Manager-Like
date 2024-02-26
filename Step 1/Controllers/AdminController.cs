using Microsoft.AspNetCore.Mvc;

namespace AD_Manager.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin(string role)
        {
            if (role == "admin")
            {
                return View();
            }
            else
            {
                // 如果角色不是 admin，可以進行其他處理，例如返回錯誤頁面或重定向到其他頁面
                return NotFound();
            }
        }
    }
}
