using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoWeb.Models
{
  /// <summary>
  /// Údaje o koľajisku.
  /// </summary>
  public class CargoRailModel
  {
    public CargoRailModel()
    {
      this.Loaders = new List<LoaderModel>();
    }

    /// <summary>
    /// ID koľajiska (poradové číslo).
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Zoznam nakladacích miest.
    /// </summary>
    public IList<LoaderModel> Loaders { get; private set; }
  }
}
