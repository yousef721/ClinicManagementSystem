using CMS.Data.Access.Layer.Data;
using CMS.Data.Access.Layer.Repository;
using CMS.Data.Access.Layer.Repository.IRepository;

//using CMS.Data.Access.Layer.Repository;
//using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Perestation.Layer.DbInitilization;
using CMS.Utitlities.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace CMS.Perestation.Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program));


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            builder.Services.AddDbContext<ApplicationDbContext>
            (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDbInitilizer, DbInitilizer>();


            builder.Services.AddTransient<IEmailSender, EmailSender>();

            // builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            //StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            //builder.Services.AddAutoMapper(e => e.AddProfile(new MappingProfile()));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();





            app.UseAuthorization();

            var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider.GetService<IDbInitilizer>();
            service.Initilizer();

            app.MapStaticAssets();

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run(); 
        }
    }
}
