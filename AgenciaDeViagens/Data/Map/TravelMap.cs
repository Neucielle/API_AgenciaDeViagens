using AgenciaDeViagens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenciaDeViagens.Data.Map
{
    public class TravelMap : IEntityTypeConfiguration<TravelModel>
    {
        public void Configure(EntityTypeBuilder<TravelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Destino).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UserId);
            builder.HasOne(x => x.User);

        }
    }
}
