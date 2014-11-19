using CargoWeb.Hubs;
using CargoWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoWeb.Controllers
{  
  /// <summary>
  /// Demonštruje editáciu destinácií a zobrazenie anonymous view pre nakladač.
  /// </summary>
  [Authorize]
  public class CargoController : Controller
  {
    /// <summary>
    /// Zobrazí default view pre editáciu destinácií jednotlivých nakladačov.
    /// </summary>
    public ActionResult Index()
    {
      return this.View(this.GetRails());
    }


    /// <summary>
    /// Na túto akciu sa musia konektovať displeje pre jednotlivé nakladače. Note: povolený
    /// anonymný prístup cez atribút aplikovaní ´metódu.
    /// </summary>
    [AllowAnonymous]
    public ActionResult LoaderView(int railId, int loaderId)
    {
      var rail = this.GetRail(railId);
      var loader = rail.Loaders.First(l => l.Id == loaderId);
      return this.View(new LoaderViewModel(railId, loader));
    }


    /// <summary>
    /// Aktualizácia destinácií daného nakladača.
    /// </summary>
    [HttpPost]
    public ActionResult UpdateDestinations(int railId, LoaderModel loader)
    {
      if (this.ModelState.IsValid)
      {
        this.UpdateLoader(railId, loader);
      }
      return this.RedirectToAction("Index");
    }


    private void UpdateLoader(int railId, LoaderModel updatedLoader)
    {
      // Brute force, žiadne ošetrenie chýb, zápis celého grafu na disk ako JSON.
      var rail = this.GetRail(railId);
      var loader = rail.Loaders.First(l => l.Id == updatedLoader.Id);
      loader.Destinations = updatedLoader.Destinations;
      System.IO.File.WriteAllText(this.GetJsonFilePath(), JsonConvert.SerializeObject(this.GetRails()));

      // Tu využívame SignalR pre dispatch notifikácií.
      CargoHub.BroadcastLoaderChanged(loader);
    }


    // Naša statická "databáza" koľajísk - zoznam je v súbore cargo.json v root foldri projektu.
    // Neserieme sa tu ani s thread-safety a lockingom...
    static List<CargoRailModel> _s_rails;

    private List<CargoRailModel> GetRails()
    {
      if (CargoController._s_rails == null)
      {
        CargoController._s_rails = JsonConvert.DeserializeObject<List<CargoRailModel>>(System.IO.File.ReadAllText(this.GetJsonFilePath()));
      }
      return CargoController._s_rails;
    }


    private CargoRailModel GetRail(int railId)
    {
      return this.GetRails().First(m => m.Id == railId);
    }

 
    private string GetJsonFilePath()
    {
      return this.Server.MapPath(@"~\cargo.json");
    }
    
  }
}
