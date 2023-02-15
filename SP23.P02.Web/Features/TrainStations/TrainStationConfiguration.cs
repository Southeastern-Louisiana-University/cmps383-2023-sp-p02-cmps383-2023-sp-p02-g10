using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP23.P02.Web.Features.TrainStations;

public class TrainStationConfiguration : IEntityTypeConfiguration<TrainStation>
{
    public void Configure(EntityTypeBuilder<TrainStation> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Address)
            .IsRequired();

        builder.HasOne(x => x.Manager)
         .WithMany()
         .HasForeignKey(x => x.ManagerId)
         .OnDelete(DeleteBehavior.ClientCascade);
    }
}