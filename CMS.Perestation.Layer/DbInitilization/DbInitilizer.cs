using CMS.Data.Access.Layer.Data;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Utitlities.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CMS.Perestation.Layer.DbInitilization
{
    public class DbInitilizer : IDbInitilizer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _dbContext;

        public DbInitilizer(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager,ApplicationDbContext dbContext) 
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }
        public async void Initilizer()
        {
            try
            {
                if (this._dbContext.Database.GetPendingMigrations().Any())
                {
                    this._dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
            if (!this._roleManager.Roles.Any())
            {
                this._roleManager.CreateAsync(new(Role.AdminRole)).GetAwaiter().GetResult();
                this._roleManager.CreateAsync(new(Role.CustomerRole)).GetAwaiter().GetResult();

            }
            if (this._userManager.FindByNameAsync("Admin").GetAwaiter().GetResult() == null)
            {
                this._userManager.CreateAsync(new()
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    ProfilePicture = "Admin.jpg",
                    PhoneNumber = "+201023456789"

                }, "@Admin123").GetAwaiter().GetResult();
                this._userManager.AddToRoleAsync(_userManager.FindByEmailAsync("Admin@gmail.com").GetAwaiter().GetResult(), Role.AdminRole);
            }
            

        }
    }
}
