using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class ClienteRepositorio : BaseRepositorio<Clientes>, IClienteRepositorio
  {
    public ClienteRepositorio(Contexto db) : base(db)
    {
    }
    public Clientes ObterPorTelefone(string telefone)
    {
     return _db.Clientes.FirstOrDefault(u => u.Telefone == telefone);
    }

    public List<Clientes> Listar()
    {
      return _db.Clientes.Where(a => a.Ativo).ToList();
    }

    public Clientes ObterPorNome(string nome)
    {
      return _db.Clientes.FirstOrDefault(u => u.Nome == nome);
    }

    public Clientes CadastrarCliente(Clientes cliente)
    {
      _db.Clientes.Add(cliente);
      _db.SaveChanges();

      return cliente;
    }
    public Clientes AlterarCliente(Clientes cliente)
    {
      _db.Clientes.Update(cliente); _db.SaveChanges();
      return cliente;
    }

    public Clientes ProcurarClientePorTelefone(String telefone)
    {
     return _db.Clientes.FirstOrDefault(c => c.Telefone == telefone);
    }

    public Clientes ProcurarClientePorCPF(String cpf)
    {
      return _db.Clientes.FirstOrDefault(c => c.Cpf == cpf);
    }
  }
}
