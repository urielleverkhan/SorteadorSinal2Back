using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class VencedoresRepositorio : BaseRepositorio<Vencedores>, IVencedoresRepositorio
  {
    public VencedoresRepositorio(Contexto db) : base(db)
    {
    }
    public List<Clientes> ListarPorPromocao(int idPromocao)
    {
      var vencedores = _db.Vencedores.Where(a => a.IdPromocao == idPromocao).ToList();

      var clientesVencedores = new List<Clientes>();

      foreach (var venc in vencedores)
      {
        var cliente = _db.Clientes.Find(venc.IdCliente);
        clientesVencedores.Add(cliente);
      }

      return clientesVencedores;
    }
    public Vencedores CadastrarVencedor(Clientes vencedorRecebido, int idPromocao)
    {
      var vencedor = new Vencedores();
      vencedor.IdCliente = vencedorRecebido.Id;
      vencedor.IdPromocao = idPromocao;

      _db.Vencedores.Add(vencedor);
      _db.SaveChanges();

      return vencedor;
    }
    public Vencedores ObterPorId(int idVencedor, int idPromocao)
    {
      return _db.Vencedores.FirstOrDefault(p => p.IdCliente == idVencedor && p.IdPromocao == idPromocao);
    }
  }
}
