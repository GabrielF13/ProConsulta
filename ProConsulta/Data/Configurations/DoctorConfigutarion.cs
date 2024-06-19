using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class DoctorConfigutarion : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Documentt)
                .IsRequired(true)
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Crm)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(8)");

            builder.Property(x => x.CellPhone)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.SpecialtyId)
                .IsRequired(true);

            builder.HasIndex(x => x.Documentt)
                .IsUnique();

            builder.HasMany(s => s.Schedulers)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}