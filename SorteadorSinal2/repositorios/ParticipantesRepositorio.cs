using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios
{
  public class ParticipantesRepositorio : BaseRepositorio<Participantes>, IParticipantesRepositorio
  {
    public ParticipantesRepositorio(Contexto db) : base(db)
    {
    }
    public List<Clientes> ListarPorPromocao(int idPromocao)
    {
      var participantes = _db.Participantes.Where(a => a.IdPromocao == idPromocao).ToList();

      var clientesParticipantes = new List<Clientes>();

     foreach(var participante in participantes){
        var cliente = _db.Clientes.Find(participante.IdCliente);
        clientesParticipantes.Add(cliente);
      }
        
      return clientesParticipantes;
    }

    public Participantes CadastrarParticipante(int idParticipante, int idPromocao)
    {
      var participante = new Participantes();
      participante.IdCliente = idParticipante;
      participante.IdPromocao = idPromocao;

      _db.Participantes.Add(participante);
      _db.SaveChanges();

      return participante;
    }

    public Participantes ObterPorId(int idCliente, int idPromocao)
    {
      return _db.Participantes.FirstOrDefault(p => p.IdCliente == idCliente && p.IdPromocao == idPromocao);
    }
  }
}
