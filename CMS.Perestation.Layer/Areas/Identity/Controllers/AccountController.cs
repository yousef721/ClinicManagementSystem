using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.IdentitySection.IdentitySectionVM;
using CMS.Utitlities.Helper;
using CMS.Utitlities.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CMS.Utitlities.Email;

namespace CMS.Perestation.Layer.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    [Route("Identity/Account")]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        //private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IEmailSender emailSender)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._emailSender = emailSender;
        }


        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            ModelState.Remove("ProfilePicture");
            if (ModelState.IsValid)
            {


                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerVM);
                applicationUser.UserName = registerVM.Email.Split('@')[0];
                applicationUser.ProfilePicture = "Profile.png";

                var result = _userManager.CreateAsync(applicationUser, registerVM.Password).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, Role.CustomerRole);
                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerVM);
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (flag)
                    {
                        await _signInManager.PasswordSignInAsync(user, loginVM.Password, isPersistent: loginVM.RemeberMe, false);
                        return RedirectToAction("Index", "Home", new { area = "Customer" });


                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Email or password is in correct");

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email or password is in correct");

                }
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            ProfileVM profileVM = new ProfileVM();
            if (user is not null)
            {
                profileVM = _mapper.Map<ProfileVM>(user);
                return View(profileVM);
            }
            return RedirectToAction("Login", "Account", new { area = "Identity" });

        }
        [HttpPost]
        [Route("Profile")]
        public async Task<IActionResult> Profile(ProfileVM profileVM, IFormFile file)
        {
            var oldProfile = await _userManager.GetUserAsync(User);
            if (oldProfile != null)
            {
                if (file != null && file.Length > 0)
                {
                    profileVM.ProfilePicture = FileOperation.UploadFile(file, "Images\\Profiles");
                    if (oldProfile.ProfilePicture != "Profile.png")
                    {
                        FileOperation.DeleteFile(oldProfile.ProfilePicture, "Images\\Profiles");
                    }
                }
                else
                {
                    profileVM.ProfilePicture = oldProfile.ProfilePicture;
                }

                oldProfile.FirstName = profileVM.FirstName;
                oldProfile.LastName = profileVM.LastName;
                oldProfile.ProfilePicture = profileVM.ProfilePicture;

                await _userManager.UpdateAsync(oldProfile);

            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            return View(profileVM);
        }

        [HttpGet]
        [Route("ChangePassword")]

        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordVM());
        }
        [HttpPost]
        [Route("ChangePassword")]

        public IActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                {
                    var result = _userManager.ChangePasswordAsync(user, changePasswordVM.OldPassword, changePasswordVM.NewPassword).GetAwaiter().GetResult();

                    return RedirectToAction("Profile", "Account", new { area = "Identity" });

                }
                else
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });

                }
            }
            return View(changePasswordVM);
        }
        [HttpGet]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View(new ForgetPasswordVM());
        }

        [HttpPost]
        [Route("ForgetPassword")]

        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgetPasswordVM.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = user.Email, Token = token }, Request.Scheme);
                    await _emailSender.SendEmailAsync(
                        email: forgetPasswordVM.Email,
                        subject: "Reset Password",
                          message: ResetPasswordLink
                        );
                    return RedirectToAction(nameof(CkeckYourMail));


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email is not Exist");
                }
            }

            return View(forgetPasswordVM);
        }
        [Route("CkeckYourMail")]

        public IActionResult CkeckYourMail()
        {
            return View();
        }
        [HttpGet]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string email, string token)
        {
            ResetPasswordVM resetPasswordVM = new ResetPasswordVM()
            {
                Email = email,
                Token = token
            };

            return View(resetPasswordVM);
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);

                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "email is not exists ");
                }
            }
            return View(resetPasswordVM);

        }
    }
}
