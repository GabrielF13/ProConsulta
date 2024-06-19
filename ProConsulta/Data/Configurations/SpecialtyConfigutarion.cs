using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class SpecialtyConfigutarion : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnType("VARCHAR(150)");

            builder.HasMany(d => d.Doctors)
                .WithOne(s => s.Specialty)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}