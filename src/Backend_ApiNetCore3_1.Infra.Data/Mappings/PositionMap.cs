using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend_ApiNetCore3_1.Domain.Models;

namespace Backend_ApiNetCore3_1.Infra.Data.Mappings
{
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

            #region Keys
            builder.HasKey(p => p.Id);
            #endregion

            #region Properties
            builder.Property(p => p.Id)
                .HasColumnName("PositionId")
                .IsRequired();


            #endregion

            #region Relations

            #endregion
        }
    }
}
