using Microsoft.EntityFrameworkCore;
using SorteadorSinal2.models;
using SorteadorSinal2.repositorios.Configs;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SorteadorSinal2.repositorios
{
  public class Contexto : Microsoft.EntityFrameworkCore.DbContext, IContexto
  {

    public Microsoft.EntityFrameworkCore.DbSet<Clientes> Clientes { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Usuarios> Usuarios { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Promocoes> Promocoes { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Participantes> Participantes { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Vencedores> Vencedores { get; set; }

    public Contexto(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClientesConfiguracao());
      modelBuilder.ApplyConfiguration(new PromocoesConfiguracao());
      modelBuilder.ApplyConfiguration(new UsuariosConfiguracao());
      modelBuilder.ApplyConfiguration(new ParticipantesConfiguracao());
      modelBuilder.ApplyConfiguration(new VencedoresConfiguracao());

      //Configurar dados obrigatórios
      ConfigurarCliente(modelBuilder);
      ConfigurarPromocoes(modelBuilder);
      ConfigurarParticipantes(modelBuilder);
      ConfigurarVencedores(modelBuilder);
      ConfigurarUsuarios(modelBuilder);

      base.OnModelCreating(modelBuilder);
    }
    private void ConfigurarUsuarios(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Usuarios>().HasData(
          new Usuarios
          {
            Id = 1,
            Nome = "Naira Danile",
            Senha = "123456",
            Login = "naira",
            Ativo = false
          },
           new Usuarios
           {
             Id = 2,
             Nome = "Josiane bueno",
             Senha = "654321",
             Login = "josi",
             Ativo = true
           }
          );
    }

    private void ConfigurarCliente(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Clientes>().HasData(
          new Clientes
          {
            Id = 1,
            Telefone = "11 99222221",
            Nome = "Maricota da Silva",
            Cpf = "222.222.222-22",
            Nascimento = "15/03/1999",
            Cidade = "Rio preto",
            Estado = "Sp",
            Ativo = true
         
          },
           new Clientes
           {
             Id = 2,
             Telefone = "11 99222222",
             Nome = "Jose pereira",
             Cpf = "222.222.222-22",
             Nascimento = "11/12/1990",
             Cidade = "Rio preto",
             Estado = "Sp",
             Ativo = true
           },
            new Clientes
            {
              Id = 3,
              Telefone = "11 99222223",
              Nome = "Joao Costa",
              Cpf = "222.222.222-22",
              Nascimento = "25/03/2018",
              Cidade = "Rio preto",
              Estado = "Sp",
              Ativo = false
            },
             new Clientes
             {
               Id = 4,
               Telefone = "11 99222224",
               Nome = "Larisa casablanca",
               Cpf = "222.222.222-22",
               Nascimento = "06/06/1949",
               Cidade = "Rio preto",
               Estado = "Sp",
               Ativo = true
             },
              new Clientes
              {
                Id = 5,
                Telefone = "11 99222225",
                Nome = "Joana camargo",
                Cpf = "222.222.222-22",
                Nascimento = "12/03/2000",
                Cidade = "Rio preto",
                Estado = "Sp",
                Ativo = true
              }
          );
    }
    private void ConfigurarPromocoes(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Promocoes>().HasData(
          new Promocoes
          {
            Id = 1,
            Nome = "Churrascaria boi feliz",
            VigenciaInicio = "10/03/2023",
            VigenciaFim = "20/03/2023",
            Ativo = true
          },
          new Promocoes
          {
            Id = 2,
            Nome = "Funeraria cliente agradecido",
            VigenciaInicio = "01/03/2023",
            VigenciaFim = "05/03/2023",
            Ativo = false
          },
          new Promocoes
          {
            Id = 3,
            Nome = "Fabrica de gelos escorrega",
            VigenciaInicio = "07/03/2023",
            VigenciaFim = "10/03/2023",
            Ativo = true
          }
          );
    }
    private void ConfigurarParticipantes(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Participantes>().HasData(
          new Participantes
          {
            Id = 1,
            IdCliente = 2,
            IdPromocao = 2
          },
          new Participantes
          {
            Id = 2,
            IdCliente = 4,
            IdPromocao = 2
          },
          new Participantes
          {
            Id = 3,
            IdCliente = 2,
            IdPromocao = 1
          },
          new Participantes
          {
            Id = 4,
            IdCliente = 1,
            IdPromocao = 2
          },
          new Participantes
          {
            Id = 5,
            IdCliente = 5,
            IdPromocao = 1
          },
           new Participantes
           {
             Id = 6,
             IdCliente = 4,
             IdPromocao = 3
           },
            new Participantes
            {
              Id = 7,
              IdCliente = 1,
              IdPromocao = 3
            }
          );
    }
    private void ConfigurarVencedores(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Vencedores>().HasData(
          new Vencedores
          {
            Id = 1,
            IdCliente = 2,
            IdPromocao = 2
          },
          new Vencedores
          {
            Id = 2,
            IdCliente = 4,
            IdPromocao = 2
          },
          new Vencedores
          {
            Id = 3,
            IdCliente = 4,
            IdPromocao = 3
          }
          );
    }


  }
}
