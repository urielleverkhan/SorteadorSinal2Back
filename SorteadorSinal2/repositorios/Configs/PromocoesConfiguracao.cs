using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorteadorSinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2.repositorios.Configs
{
  public class PromocoesConfiguracao : IEntityTypeConfiguration<Promocoes>
  {
    public void Configure(EntityTypeBuilder<Promocoes> builder)
  {
      builder.HasKey(e => e.Id);
      builder.Property(c => c.Nome).IsRequired();
      builder.Property(e => e.VigenciaInicio).IsRequired();
      builder.Property(x => x.VigenciaFim).IsRequired();
    }
  }
}
