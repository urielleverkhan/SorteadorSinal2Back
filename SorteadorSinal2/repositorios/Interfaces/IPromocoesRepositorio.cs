using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IPromocoesRepositorio : IBaseRepository<Promocoes>
  {
    Promocoes ObterPromocaoPorId(int id);
    List<Promocoes> ListarFinalizadas();
    List<Promocoes> ListarAtivas();
    Promocoes CadastrarPromocao(Promocoes promocao);
    Promocoes AlterarPromocao(Promocoes promocao);
  }
}
