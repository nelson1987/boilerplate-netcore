using FluentValidation;
using Stargazer.Domain.Entities;

namespace Stargazer.Application.Features.Movements;
public record AddMovementCommand
{
    public decimal Valor { get; init; }
    public Status Status { get; init; }

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
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.Valor).NotEmpty();
        RuleFor(x => x.Valor).GreaterThan(0);
    }
}