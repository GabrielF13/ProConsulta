using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Id = "8305f33b-5412-47d0-b4ab-17cf6867f2e2",
                    Name = "Atendente",
                    NormalizedName = "ATENDENTE"
                },
                new IdentityRole
                {
                    Id = "00043fbd-e5e1-49eb-8e36-837561d584f1",
                    Name = "Medico",
                    NormalizedName = "MEDICO"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Attendant>().HasData
            (
                new Attendant
                {
                    Id = "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                    Name = "Pro Consulta",
                    Email = "proconsulta@hotmail.com.br",
                    EmailConfirmed = true,
                    UserName = "proconsulta@hotmail.com.br",
                    NormalizedEmail = "PROCONSULTA@HOTMAIL.COM.BR",
                    NormalizedUserName = "PROCONSULTA@HOTMAIL.COM.BR",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    RoleId = "8305f33b-5412-47d0-b4ab-17cf6867f2e2",
                    UserId = "95433ac4-2fe9-468f-b80d-b05ec3724d1d"
                }
            );

            _modelBuilder.Entity<Specialty>().HasData
            (
                new Specialty { Id = 1, Name = "Cardiologia", Description = "Especialidade médica que trata doenças do coração e do sistema cardiovascular." },
                new Specialty { Id = 2, Name = "Dermatologia", Description = "Especialidade médica que trata doenças da pele, cabelo e unhas." },
                new Specialty { Id = 3, Name = "Gastroenterologia", Description = "Especialidade médica que trata doenças do sistema digestivo." },
                new Specialty { Id = 4, Name = "Neurologia", Description = "Especialidade médica que trata doenças do sistema nervoso." },
                new Specialty { Id = 5, Name = "Ortopedia", Description = "Especialidade médica que trata doenças e lesões do sistema musculoesquelético." },
                new Specialty { Id = 6, Name = "Pediatria", Description = "Especialidade médica que trata de crianças e adolescentes." },
                new Specialty { Id = 7, Name = "Psiquiatria", Description = "Especialidade médica que trata de doenças mentais e distúrbios emocionais." },
                new Specialty { Id = 8, Name = "Oftalmologia", Description = "Especialidade médica que trata doenças dos olhos." },
                new Specialty { Id = 9, Name = "Ginecologia", Description = "Especialidade médica que trata do sistema reprodutor feminino." },
                new Specialty { Id = 10, Name = "Oncologia", Description = "Especialidade médica que trata do câncer." }
            );
        }
    }
}
