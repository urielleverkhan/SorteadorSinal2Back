using SorteadorSinal2.models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.models
{
  public class Promocoes
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string VigenciaInicio { get; set; }
    public string VigenciaFim { get; set; }
    public Boolean Ativo { get; set; }
  }
}
