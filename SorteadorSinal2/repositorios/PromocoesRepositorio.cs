using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class PromocoesRepositorio : BaseRepositorio<Promocoes>, IPromocoesRepositorio
  {
    public PromocoesRepositorio(Contexto db) : base(db)
    {
    }
    public Promocoes ObterPromocaoPorId(int id) {
      return _db.Promocoes.FirstOrDefault(p => p.Id == id);
    }

    public List<Promocoes> ListarFinalizadas() {
      return _db.Promocoes.Where(p => p.Ativo == false).ToList();
    }
    public List<Promocoes> ListarAtivas()
    {
      return _db.Promocoes.Where(p => p.Ativo == true).ToList();
    }
    public Promocoes CadastrarPromocao(Promocoes promocaoRecebida)
    {
      _db.Promocoes.Add(promocaoRecebida);
      _db.SaveChanges();

      return promocaoRecebida;

    }
    public Promocoes AlterarPromocao(Promocoes promocao)
    {
      _db.Promocoes.Update(promocao);
      _db.SaveChanges();

      return promocao;
    }

  }
}
