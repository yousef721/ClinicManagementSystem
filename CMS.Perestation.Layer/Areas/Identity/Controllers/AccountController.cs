using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.IdentitySection.IdentitySectionVM;
using CMS.Utitlities.Helper;
using CMS.Utitlities.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CMS.Perestation.Layer.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    [Route("Identity/Account")]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public AccountController( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._mapper = mapper; 
            
        }


        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        [Route("Register")]
        public async Task< IActionResult> Register(RegisterVM registerVM , IFormFile ProfilePicture)
        {
            ModelState.Remove("ProfilePicture");
            if (ModelState.IsValid)
            {
                if (ProfilePicture != null && ProfilePicture.Length > 0)
                {
                    registerVM.ProfilePicture = FileOperation.UploadFile(ProfilePicture, "Images\\Profiles");
                }
                else
                {
                    registerVM.ProfilePicture = "Profile.png";
                }

                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerVM);
                applicationUser.UserName = registerVM.Email.Split('@')[0];

                var result = _userManager.CreateAsync(applicationUser,registerVM.Password).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    await   _userManager.AddToRoleAsync(applicationUser, Role.CustomerRole);
                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home" , new {area = "Home"});
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
                        return RedirectToAction("Index", "Home", new { area = "Home" });


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
            return RedirectToAction("Index", "Home", new { area = "Home" });
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
    }
}
