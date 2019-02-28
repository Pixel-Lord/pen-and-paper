using System;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore;
using PenAndPaper.Interfaces.Startups;
using PenAndPaper.Abstracts.Setups;

namespace PenAndPaper.NUnit.HelpClasses.TestServers
{
  public class PAPTestServer//<TStartup> : IDisposable where TStartup : BaseStartup
  {
    private TestServer _server;
    public HttpClient Client { get; set; }

    public PAPTestServer() => SetUpServerAndClient();
    

    private void SetUpServerAndClient()
    {
      this._server = new TestServer(PAPWebHostBuilder());

      this.Client = _server.CreateClient();
    }

    private IWebHostBuilder PAPWebHostBuilder()
    {
      var contentRootPath = Path.GetFullPath(Path.Combine
        (Directory.GetCurrentDirectory(), "..", "..", "..", "..", "PenAndPaper"));

      return WebHost.CreateDefaultBuilder<Startup>(args: null)
        .UseContentRoot(contentRootPath)
        .UseEnvironment("Development")
        .UseStartup<Startup>();
    }

    public void Dispose()
    {
      Client.Dispose();
      _server.Dispose();
    }
  }
}
