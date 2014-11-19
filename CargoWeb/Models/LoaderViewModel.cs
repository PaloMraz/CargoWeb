using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoWeb.Models
{
  /// <summary>
  /// Read-only info o nakladacom mieste na koľajisku.
  /// </summary>
  public class LoaderViewModel
  {
    public LoaderViewModel(int railId, LoaderModel loader)
    {
      this.RailId = railId;
      this.Id = loader.Id;
      this.Destinations = new List<string>(loader.Destinations.Split(' ', '\n', '\t'));
    }


    public int RailId { get; private set; }

    /// <summary>
    /// ID nakladacieho miesta.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Zoznam destinácií - predpokladáme whitespace delimited zoznam.
    /// </summary>
    public IList<string> Destinations { get; private set; }
  }
}
