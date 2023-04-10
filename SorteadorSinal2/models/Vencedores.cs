using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.models
{
  public class Vencedores
  {
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public virtual Clientes Clientes { get; set; }
    public int IdPromocao { get; set; }
    public virtual Promocoes Promocoes { get; set; }
  }
}
