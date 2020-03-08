using Backend_ApiNetCore3_1.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_ApiNetCore3_1.Infra.Data.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");

            #region Keys
            builder.HasKey(p => p.Id);
            #endregion

            #region Properties
            builder.Property(c => c.Id)
                    .HasColumnName("UserId");


            #endregion



            #region Relations


            #endregion

            #region Ignore

            #endregion
        }
    }
}
