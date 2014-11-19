using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using CargoWeb.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace CargoWeb.Hubs
{
  public class CargoHub : Hub
  {
    public CargoHub()
    { }


    public static void BroadcastLoaderChanged(LoaderModel loader)
    {
      var context = GlobalHost.ConnectionManager.GetHubContext<CargoHub>();
      context.Clients.All.OnLoaderChanged(loader);
    }
  }
}