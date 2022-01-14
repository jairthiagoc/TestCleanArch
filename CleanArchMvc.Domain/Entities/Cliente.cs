using CleanArchMvc.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Cliente
    {
        
        public Guid Id { get; set; }
        public string? Name { get; private set; }

        public Int64? Idade { get; private set; }

        public Cliente(string name)
        {
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }

        public Cliente(Guid id, string name, int idade)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid Id. Id do not is empty");

            Id = id;

            DomainExceptionValidation.When(idade <= 0, "Invalid Age. Age do not is negative or zero");

            Idade = idade;

            ValidationDomain(name);
        }
    }
}
