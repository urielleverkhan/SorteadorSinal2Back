using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class BaseRepositorio<TEntity> : IBaseRepository<TEntity> where TEntity : class
  {
    protected readonly Contexto _db;
    public BaseRepositorio(Contexto db)
    {
      _db = db;
    }
    public void Adicionar(TEntity entity)
    {
      _db.Set<TEntity>().Add(entity);
      _db.SaveChanges();
    }

    public TEntity AdicionarComRetorno(TEntity entity)
    {
      _db.Set<TEntity>().Add(entity);
      _db.SaveChanges();

      return entity;
    }

    public void Atualizar(TEntity entity)
    {

      _db.Set<TEntity>().Update(entity);
      _db.SaveChanges();
    }


    public TEntity ObterPorId(int id)
    {
      var retorno = _db.Set<TEntity>().Find(id);
      return retorno;
    }

    public IEnumerable<TEntity> ObterTodos()
    {
      var retorno = _db.Set<TEntity>().ToList();
      return retorno;
    }

    public void Remover(TEntity entity)
    {
      _db.Set<TEntity>().Remove(entity);
      _db.SaveChanges();
    }
  }
}
