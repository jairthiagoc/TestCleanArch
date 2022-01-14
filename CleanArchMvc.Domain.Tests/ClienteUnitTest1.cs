using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ClienteUnitTest1
    {
        [Fact(DisplayName ="Create cliente with validate state")]
        public void CreateCliente_WithValidParameters_ResultObjectValidadState()
        {
            Action action = () => new Cliente(Guid.NewGuid(), "Ana Maria Costa", 24);
            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCliente_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Cliente(Guid.Parse("00000000-0000-0000-0000-000000000000"), "Roberta da luz pereira",8);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id. Id do not is empty");
        }

        [Fact]
        public void CreateCliente_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Cliente(Guid.NewGuid(), "Ca",14);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCliente_MissingNameValue_DomainExceptionRequiredAge()
        {
            Action action = () => new Cliente(Guid.NewGuid(), "",0);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Age. Age do not is negative or zero");
        }


        [Fact]
        public void CreateCliente_WithNullNameValue_DomainExceptionInvalidAge()
        {
            Action action = () => new Cliente(Guid.NewGuid(), null,-1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Age. Age do not is negative or zero");
        }
    }

}