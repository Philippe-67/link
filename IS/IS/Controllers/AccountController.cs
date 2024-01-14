using IS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Subscription()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscription(SubscriptionViewModel subscriptionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(subscriptionVM);
            }
            var result = await this.userManager.CreateAsync(new User
            {
                Email = subscriptionVM.Email,
                UserName = subscriptionVM.Email,
                FirsName = subscriptionVM.FirstName,
                LastName = subscriptionVM.LastName,
            }, subscriptionVM.Password);

            if (result.Succeeded)

                return RedirectToAction("index", "Home");
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(subscriptionVM);
            }
        }
    }
}


    
