using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PenAndPaper.Interfaces.Startups
{
  public interface IPAPStartup
  {
    void SetupDataBase(IServiceCollection services, IConfiguration Configuration);
  }
}
