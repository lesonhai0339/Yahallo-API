using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Application.Common.Behaviours;

public sealed class SafeLoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;

    public SafeLoggingBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Yahallo request started: {RequestName} by {UserId}",
            typeof(TRequest).Name,
            _currentUserService.UserId ?? "anonymous");

        return Task.CompletedTask;
    }
}

public sealed class SafePerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;

    public SafePerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var response = await next();
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 500)
        {
            _logger.LogWarning(
                "Yahallo long-running request: {RequestName} took {ElapsedMilliseconds} ms for {UserId}",
                typeof(TRequest).Name,
                stopwatch.ElapsedMilliseconds,
                _currentUserService.UserId ?? "anonymous");
        }

        return response;
    }
}
