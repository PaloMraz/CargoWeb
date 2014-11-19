using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoWeb.Models
{
  /// <summary>
  /// Info o nakladacom mieste na koľajisku.
  /// </summary>
  public class LoaderModel
  {
    /// <summary>
    /// ID nakladacieho miesta (napr. poradové číslo).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Zoznam destinácií - predpokladáme whitespace delimited zoznam.
    /// </summary>
    public string Destinations { get; set; }
  }
}
