using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IClienteRepositorio : IBaseRepository<Clientes>
  {
    Clientes ObterPorTelefone(string telefone);
    List<Clientes> Listar();
    Clientes ObterPorNome(string nome);
    Clientes CadastrarCliente(Clientes cliente);
    Clientes AlterarCliente(Clientes cliente);
  }
}
