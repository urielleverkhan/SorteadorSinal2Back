using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Interfaces
{
  public interface IParticipantesRepositorio : IBaseRepository<Participantes>
  {
    List<Clientes> ListarPorPromocao(int idPromocao);
    Participantes CadastrarParticipante(int idParticipante, int idPromocao);
    Participantes ObterPorId(int idParticipante, int idPromocao);
  }
}
