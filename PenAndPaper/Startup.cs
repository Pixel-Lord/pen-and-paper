using Microsoft.Extensions.Configuration;

namespace PenAndPaper
{
  public class Startup : PAPStartupBase
  {
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }
  }
}
