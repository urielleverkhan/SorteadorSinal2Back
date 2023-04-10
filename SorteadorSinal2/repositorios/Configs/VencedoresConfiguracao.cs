using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Configs
{
  public class VencedoresConfiguracao : IEntityTypeConfiguration<Vencedores>
  {
    public void Configure(EntityTypeBuilder<Vencedores> builder)
    {
      builder.HasKey(e => e.Id);
      builder.HasOne(c => c.Promocoes);
      builder.HasOne(e => e.Clientes);
    }
  }
}
