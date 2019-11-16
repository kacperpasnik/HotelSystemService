using HSS.Algorithms;
using HSS.App_Start;
using HSS.DAL;
using HSS.Models;
using HSS.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HSS.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            if (!Request.IsAuthenticated)
            {
                return View();
            }

            else
              return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Login, HotelName = model.HotelName};
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);   
                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }


            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!Request.IsAuthenticated)
            {
                return View();
            }

            else
                return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Nie powoduje to liczenia niepowodzeń logowania w celu zablokowania konta
            // Aby włączyć wyzwalanie blokady konta po określonej liczbie niepomyślnych prób wprowadzenia hasła, zmień ustawienie na shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberAcc, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberAcc });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid Login or Password.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }



        //Mine

        //[HttpPost]
        //public ActionResult Register(RegisterViewModel register)
        //{
        //    ViewBag.Number = 0;
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Message = "Enter valid Login and Password.";
        //        return View("Register", register.Login);
        //    }
        //    else
        //    {
        //        if (CheckAndAdd.CheckLogin(register.Login))
        //        {

        //            HSSContext db = new HSSContext();
        //            Account newAccount = new Account()
        //            {
        //                Login = register.Login,
        //                Password = register.Password
        //            };
        //            db.Accounts.Add(newAccount);
        //            db.SaveChanges();
        //            ViewBag.Number = 1;
        //            ViewBag.Message = "New account has been created successfully!";
        //            return View();
        //        }

        //        else
        //        {
        //            ViewBag.Number = 0;
        //            ViewBag.Message = "Such Login already exists!";
        //            return View();
        //        }
        //    }

        //}

    }
}