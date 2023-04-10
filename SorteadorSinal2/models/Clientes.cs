using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.models
{
  public class Clientes
  {
    public int Id { get; set; }
    public string Telefone { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set;  }
    public string Nascimento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public Boolean Ativo { get; set; }

  }
}
