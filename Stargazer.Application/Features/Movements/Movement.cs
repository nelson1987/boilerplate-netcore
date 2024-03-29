using FluentValidation;
using Stargazer.Domain.Entities;

namespace Stargazer.Application.Features.Movements;
public record AddMovementCommand
{
    public decimal Valor { get; init; }
    public required string Conta { get; init; }

    public static implicit operator Movement(AddMovementCommand v)
    {
        return new Movement
        {
            Valor = v.Valor,
            Status = Status.Pending
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