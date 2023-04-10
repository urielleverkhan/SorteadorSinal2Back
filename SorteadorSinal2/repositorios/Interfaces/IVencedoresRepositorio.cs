using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IVencedoresRepositorio : IBaseRepository<Vencedores>
  {
    List<Clientes> ListarPorPromocao(int idPromocao);
    Vencedores CadastrarVencedor(Clientes vencedorRecebido, int idPromocao);
    Vencedores ObterPorId(int idVencedor, int idPromocao);
  }
}
