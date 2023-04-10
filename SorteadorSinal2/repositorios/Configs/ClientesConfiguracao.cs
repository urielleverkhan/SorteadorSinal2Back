
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Configs
{
  public class ClientesConfiguracao : IEntityTypeConfiguration<Clientes>
  {
    public void Configure(EntityTypeBuilder<Clientes> builder)
    {
      builder.HasKey(e => e.Id);
      builder.Property(c => c.Telefone).IsRequired();
      builder.Property(c => c.Cpf).IsRequired();
      builder.Property(e => e.Nome).IsRequired();
      builder.Property(x => x.Nascimento).IsRequired();
      builder.Property(c => c.Cidade).IsRequired();
      builder.Property(e => e.Estado).HasMaxLength(2);
    }
  }
}
