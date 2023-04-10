using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class UsuarioRepositorio : BaseRepositorio<Usuarios>, IUsuarioRepositorio
  {
    public UsuarioRepositorio(Contexto db) : base(db)
    {
    }
    public Usuarios Logar( string login)
    {
      return _db.Usuarios.FirstOrDefault(u => u.Login == login);
    }

    public List<Usuarios> Listar()
    {
      return _db.Usuarios.Where(a => a.Ativo).ToList();
    }

    public Usuarios ObterPorNome(string nome)
    {
      return _db.Usuarios.FirstOrDefault(u => u.Nome == nome) ;
    }
    public Usuarios CadastrarUsuario(Usuarios usuario)
    {
      _db.Usuarios.Add(usuario);
      _db.SaveChanges();

      return usuario;
    }
    public Usuarios AlterarUsuario(Usuarios usuario)
    {
      _db.Usuarios.Update(usuario); _db.SaveChanges();
      return usuario;
    }

  }
}
