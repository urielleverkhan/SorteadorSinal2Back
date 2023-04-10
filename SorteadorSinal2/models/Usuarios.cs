using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.models
{
  public class Usuarios
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Login { get; set; }

    public Boolean Ativo { get; set; }
  }
}
