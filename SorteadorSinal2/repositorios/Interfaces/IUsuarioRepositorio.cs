using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IUsuarioRepositorio : IBaseRepository<Usuarios>
  {
    Usuarios Logar(string login);
    List<Usuarios> Listar();
    Usuarios ObterPorNome(string nome);
    Usuarios CadastrarUsuario(Usuarios usuario);
    Usuarios AlterarUsuario(Usuarios usuario);
  }
}
