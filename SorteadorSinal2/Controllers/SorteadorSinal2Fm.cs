using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SorteadorSinal2.models.ViewModels;
using SorteadorSinal2.repositorios.Interfaces;
using AutoMapper;

namespace SorteadorSinal2.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/")]
  public class SorteadorSinal2Controller : ControllerBase
  {
    private IClienteRepositorio _dbCLiente;
    private IUsuarioRepositorio _dbUsuario;
    private IPromocoesRepositorio _dbPromocoes;
    private IParticipantesRepositorio _dbParticipantes;
    private IVencedoresRepositorio _dbVencedores;

    public SorteadorSinal2Controller(
      IClienteRepositorio dbCLiente,
      IUsuarioRepositorio dbUsuario,
      IPromocoesRepositorio dbPromocoes,
      IParticipantesRepositorio dbParticipantes,
      IVencedoresRepositorio dbVencedores)
    {
      _dbCLiente = dbCLiente;
      _dbUsuario = dbUsuario;
      _dbPromocoes = dbPromocoes;
      _dbParticipantes = dbParticipantes;
      _dbVencedores = dbVencedores;
    }


    [HttpPost("Login")]
    [AllowAnonymous]
    public ActionResult Logar([FromBody] LogarViewModel loginRecebido)
    {
      try
      {
        var usuarioEncontrado = _dbUsuario.Logar(loginRecebido.login);
        if (usuarioEncontrado != null)
        {
          if (loginRecebido.login == usuarioEncontrado.Login && loginRecebido.senha == usuarioEncontrado.Senha )
          {
            if(usuarioEncontrado.Ativo == false)
            {
              return BadRequest(new { mensagem = "Usuario inativo" });
            }
            return Ok(usuarioEncontrado);
          }
        }

        return BadRequest(new { mensagem = "Usuario ou senha invalido" });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("CadastrarCliente")]
    [AllowAnonymous]
    public ActionResult CadastrarCliente([FromBody] Clientes clienteRecebido)
    {
      try
      {
        var clienteACadastrar = new Clientes();
        clienteACadastrar.Ativo = true;
        clienteACadastrar.Cidade = clienteRecebido.Cidade;
        clienteACadastrar.Estado = clienteRecebido.Estado;
        clienteACadastrar.Nascimento = clienteRecebido.Nascimento;
        clienteACadastrar.Nome = clienteRecebido.Nome;
        clienteACadastrar.Telefone = clienteRecebido.Telefone;

        if(clienteRecebido.Cpf == null)
        {
          clienteACadastrar.Cpf = "00000000000";
        }
        else
        {
          clienteACadastrar.Cpf = clienteRecebido.Cpf;
        }

        var clienteExistente = _dbCLiente.ObterPorTelefone(clienteRecebido.Telefone);

        if (clienteExistente == null)
        {
          _dbCLiente.CadastrarCliente(clienteACadastrar);
          return Ok(new { clienteACadastrar });
        }
      
          return BadRequest(new { mensagem = "Telefone ja cadastrado" });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("CadastrarUsuario")]
    [AllowAnonymous]
    public ActionResult CadastrarUsuario([FromBody] Usuarios usuarioRecebido)
    {
      try
      {

        var usuarioACadastrar = new Usuarios();
        usuarioACadastrar.Ativo = true;
        usuarioACadastrar.Login = usuarioRecebido.Login;
        usuarioACadastrar.Nome = usuarioRecebido.Nome;
        usuarioACadastrar.Senha = usuarioRecebido.Senha;

        var usuarioExistente = _dbUsuario.Logar(usuarioRecebido.Login);

        if (usuarioExistente == null)
        {
          _dbUsuario.CadastrarUsuario(usuarioACadastrar);
          return Ok(new { usuarioACadastrar });
        }

        return BadRequest(new { mensagem = "login ja cadastrado" });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("Sortear")]
    [AllowAnonymous]
    public ActionResult Sortear(int idPromocao)
    {
      try
      {

        var ganhador = new Clientes();
        var promocao = _dbPromocoes.ObterPorId(idPromocao);
        var participantes = _dbParticipantes.ListarPorPromocao(idPromocao);
        var ganhadoresAnteriores = _dbVencedores.ListarPorPromocao(idPromocao);
        var random = new Random();
        var indice = random.Next(participantes.Count);
        ganhador = participantes[indice];
        var existeGanhador = ganhadoresAnteriores.Find(g => g.Id == ganhador.Id);

        if (promocao == null)
        {
          return BadRequest(new { mensagem = "Promoção não encontrada!" });
        }

        while(ganhador == null)
        {
          indice = random.Next(participantes.Count);
          ganhador = participantes[indice];
        }

       while(existeGanhador != null)
       {
            indice = random.Next(participantes.Count);
            ganhador = participantes[indice];
            existeGanhador = ganhadoresAnteriores.Find(g => g.Id == ganhador.Id);
        }
       
       _dbVencedores.CadastrarVencedor(ganhador, promocao.Id);
       return Ok(new { ganhador});
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("CadastrarPromocao")]
    [AllowAnonymous]
    public ActionResult CadastrarPromocao([FromBody] Promocoes promocaoRecebida)
    {
      try
      {
        var promocaoACadastrar = new Promocoes();
        promocaoACadastrar.Ativo = true;
        promocaoACadastrar.Nome = promocaoRecebida.Nome;
        promocaoACadastrar.VigenciaInicio = promocaoRecebida.VigenciaInicio;
        promocaoACadastrar.VigenciaFim = promocaoRecebida.VigenciaFim;

       _dbPromocoes.CadastrarPromocao(promocaoACadastrar);
        return Ok(new { promocaoACadastrar });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("VincularClienteAPromocao")]
    [AllowAnonymous]
    public ActionResult VincularClienteAPromocao(String telefoneClienteRecebido, int idPromocaoRecebida)
    {
      try
      {
        var promocao = _dbPromocoes.ObterPromocaoPorId(idPromocaoRecebida);
        var cliente = _dbCLiente.ObterPorTelefone(telefoneClienteRecebido);

        if(_dbParticipantes.ObterPorId(cliente.Id, promocao.Id) != null)
        {
          return BadRequest(new { mensagem = "Usuario ja cadastrado nesta promoção." });
        }

        if (cliente == null)
        {
          return BadRequest(new { mensagem = "Usuario não encontrado!" });
        }
        if (promocao == null)
        {
          return BadRequest(new { mensagem = "Promoção não encontrada!" });
        }

        _dbParticipantes.CadastrarParticipante(cliente.Id, promocao.Id);
        return Ok(new { mensagem = "Usuario cadastrado na prommocao", });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }
    }

    [HttpGet("ListarUsuarios")]
    [AllowAnonymous]
    public ActionResult ListarUsuarios()
    {
      try
      {
        var usuarios = new List<Usuarios>();
        usuarios = _dbUsuario.Listar();
       
        return Ok(new { usuarios });

      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpGet("ListarClientes")]
    [AllowAnonymous]
    public ActionResult ListarClientes()
    {
      try
      {
        var clientes = new List<Clientes>();
        clientes = _dbCLiente.Listar();

       return Ok(new { clientes });
  

      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpGet("ListarPromocoesAtivas")]
    [AllowAnonymous]
    public ActionResult ListarPromocoesAtivas()
    {
      try
      {
        var promocoes = new List<Promocoes>();
        promocoes = _dbPromocoes.ListarAtivas();
        return Ok(new { promocoes });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpGet("ListarPromocoesFinalizadas")]
    [AllowAnonymous]
    public ActionResult ListarPromocoesFinalizadas()
    {
      try
      {
        var promocoes = new List<Promocoes>();
        promocoes = _dbPromocoes.ListarFinalizadas();
        return Ok(new { promocoes });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }


    }

    [HttpPost("ListarGanhadores")]
    [AllowAnonymous]
    public ActionResult ListarGanhadores(int idPromocao)
    {
      try
      {
        var ganhadores = new List<Clientes>();
        var promocao = _dbPromocoes.ObterPorId(idPromocao);
        if (promocao == null)
        {
          return BadRequest(new { mensagem = "Promoção não encontrada!" });
        }
        ganhadores = _dbVencedores.ListarPorPromocao(idPromocao);
        return Ok(new { ganhadores });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }
    }


    [HttpPost("ListarParticipantes")]
    [AllowAnonymous]
    public ActionResult ListarParticipantes(int idPromocao)
    {
      try
      {
        var participantes = new List<Clientes>();
        var promocao = _dbPromocoes.ObterPorId(idPromocao);
        if (promocao == null)
        {
          return BadRequest(new { mensagem = "Promoção não encontrada!" });
        }
        participantes = _dbParticipantes.ListarPorPromocao(idPromocao);
        return Ok(new { participantes });
      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }
    }

    [HttpGet("Aniversariantes")]
    [AllowAnonymous]
    public ActionResult Aniversariantes()
    {
      try
      {
        var aniversariantesMes = new List<Clientes>();
        var aniversariantesSemana = new List<Clientes>();

        return Ok(new { aniversariantesMes, aniversariantesSemana });


      }
      catch (Exception erro)
      {
        return BadRequest(new { mensagem = $"Ihhh deu algum erro: {erro.Message}" });
      }
    }
  }
}
