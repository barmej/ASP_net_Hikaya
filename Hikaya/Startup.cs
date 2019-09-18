using Hikaya.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hikaya.Startup))]
namespace Hikaya
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //وحساب مدير التطبيق "Admin" هنا نقوم بإنشاء دور مدير التطبيق 
            if (!roleManager.RoleExists("Admin"))
            {
                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                roleManager.Create(adminRole);
                //هنا نقوم بإنشاء حساب مدير التطبيق
                ApplicationUser adminUser = new ApplicationUser();
                adminUser.UserName = "admin@test.test";
                adminUser.Email = "admin@test.test";
                string password = "P@ssw0rd";
                IdentityResult result = userManager.Create(adminUser, password);
                //نتحقق من إنشاء المستخدم بنجاح ثم نضيفه إلى دور مدير التطبيق
                if (result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Admin");
                }
            }
        }
    }
}
