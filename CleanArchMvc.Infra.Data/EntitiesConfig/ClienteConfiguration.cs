using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Infra.Data.EntitiesConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Idade).HasMaxLength(3).IsRequired();
            
            builder.HasData(
                new Cliente(Guid.NewGuid(), "Joao Luz da Silva", 15),
                new Cliente(Guid.NewGuid(), "Maria Ivotete Costa",25),
                new Cliente(Guid.NewGuid(), "Aderbaldo Oliveira Souza", 39),
                new Cliente(Guid.NewGuid(), "Romarildo de Alencar Silveira", 42),
                new Cliente(Guid.NewGuid(), "Joana da Silva Pereira", 32)
                );
        }
    }
}
