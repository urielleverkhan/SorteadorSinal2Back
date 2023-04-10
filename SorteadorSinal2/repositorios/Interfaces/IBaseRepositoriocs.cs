using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IBaseRepository<TEntity> where TEntity : class
  {
    void Adicionar(TEntity entity);
    void Atualizar(TEntity entity);
    void Remover(TEntity entity);
    TEntity ObterPorId(int id);
    IEnumerable<TEntity> ObterTodos();
  }
}
