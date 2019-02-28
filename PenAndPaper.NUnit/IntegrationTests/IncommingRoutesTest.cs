using NUnit.Framework;
using PenAndPaper.NUnit.HelpClasses.TestServers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PenAndPaper.NUnit.IntegrationTests
{
  [TestFixture]
  public class IncommingRoutesTest : IDisposable
  {
    private PAPTestServer _server { get; set; }
    private HttpClient Client { get; set; }

    [OneTimeSetUp]
    public void SetUp()
    {
      _server = new PAPTestServer();
      Client = _server.Client;
    }

    [Test]
    public async Task Test()
    {
      var response = await Client.GetAsync("/");
      var responseString = await response.Content.ReadAsStringAsync();
      Assert.Pass();
    }

    [OneTimeTearDown]
    public void Dispose()
    {
      _server.Dispose();
    }
  }
}
