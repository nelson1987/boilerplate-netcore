using FluentValidation;
using Stargazer.Domain.Entities;

namespace Stargazer.Application.Features.Movements;
public record AddMovementCommand
{
    public decimal Valor { get; init; }
    public required string Conta { get; init; }

    public Movement MapToEntity()
    {
        return new Movement
        {
            Conta = Conta,
            Valor = Valor,
            Status = Status.Pending,
            CreatedBy = "Command",
            Created = DateTime.Now,
            LastModifiedBy = "Command",
            LastModified = DateTime.Now
        };
    }
}

public class AddMovementCommandValidator : AbstractValidator<AddMovementCommand>
{
    public AddMovementCommandValidator()
    {
        RuleFor(x => x.Conta)
            .NotEmpty();
        RuleFor(x => x.Valor)
            .NotEmpty()
            .GreaterThan(0);
    }
}