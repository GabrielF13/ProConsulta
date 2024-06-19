using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class PatientConfigutarion : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Document)
               .IsRequired(true)
               .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Email)
               .IsRequired(true)
               .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Cellphone)
               .IsRequired(true)
               .HasColumnType("NVARCHAR(11)");

            builder.HasIndex(x => x.Document)
                .IsUnique();

            builder.HasMany(a => a.Schedulers)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
