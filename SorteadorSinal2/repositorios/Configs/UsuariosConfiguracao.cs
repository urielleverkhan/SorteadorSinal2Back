using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Configs
{
  public class UsuariosConfiguracao : IEntityTypeConfiguration<Usuarios>
  {
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Nome).IsRequired();
      builder.Property(x => x.Senha).IsRequired();
      builder.Property(c => c.Login).IsRequired();
    }
  }
}
