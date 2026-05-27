namespace YAHALLO.Application.Common.Events
{
    public sealed record MangaChangedEvent(
        string MangaId,
        string ChangeType,
        string? UserId,
        DateTime OccurredAtUtc);
}

