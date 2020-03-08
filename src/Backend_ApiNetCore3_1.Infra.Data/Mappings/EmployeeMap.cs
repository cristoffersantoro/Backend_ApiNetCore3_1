using Backend_ApiNetCore3_1.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_ApiNetCore3_1.Infra.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            #region Keys
            builder.HasKey(p => p.Id);
            #endregion

            #region Properties
            builder.Property(p => p.Id)
                .HasColumnName("EmployeeId")
                .IsRequired();


            #endregion

            #region Relations

            builder.HasOne(p => p.Position)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(fk => fk.PositionId);
            #endregion
        }
    }
}
