using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Stargazer.Application.Features.Movements;
using Stargazer.Domain.Features.Movements;
using Stargazer.Infrastructure.Persistence.Repositories;
using Stargazer.WebApi.Extensions;

namespace Stargazer.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovementsController : ControllerBase
{
    private readonly ILogger<MovementsController> _logger;
    private readonly IValidator<AddMovementCommand> _validator;
    private readonly IMovementRepositoryAsync _readRepository;
    private readonly IAddMovementCommandHandler _handler;

    public MovementsController(ILogger<MovementsController> logger,
        IValidator<AddMovementCommand> validator,
        IMovementRepositoryAsync readRepository,
        IAddMovementCommandHandler handler)
    {
        _logger = logger;
        _validator = validator;
        _readRepository = readRepository;
        _handler = handler;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movement>>> Get(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get");
        return Ok(await _readRepository.GetAsync(cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movement?>> GetById([FromRoute] string id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetById");
        return Ok(await _readRepository.GetAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult> Post(AddMovementCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Post");
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsInvalid())
            return UnprocessableEntity(validationResult.ToModelState());

        var result = await _handler.Handle(command, cancellationToken);
        return result.IsFailed
            ? BadRequest()
            : Created();
    }
}