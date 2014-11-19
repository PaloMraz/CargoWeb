using Microsoft.Owin;
using Owin;

namespace CargoWeb
{
  /// <summary>
  /// Convention-based aktivácia SignalR.
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.MapSignalR();
    }
  }
}
