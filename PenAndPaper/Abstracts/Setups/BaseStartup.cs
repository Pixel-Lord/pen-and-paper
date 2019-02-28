using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PenAndPaper.Data;
using PenAndPaper.Interfaces.Startups;

namespace PenAndPaper.Abstracts.Setups
{
  public abstract class BaseStartup : IPAPStartup
  {
    public virtual void SetupDataBase(IServiceCollection services, IConfiguration Configuration)
    {
      // "DefaultConnection" bezieht sich auf die appsettings connection
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      services.AddDefaultIdentity<IdentityUser>()
          .AddEntityFrameworkStores<ApplicationDbContext>();

      // !!!Dependenci Injection for allowing the Framework to take care of the desposing!!!
      services.AddTransient<ApplicationDbContext>();
    }
  }
}
