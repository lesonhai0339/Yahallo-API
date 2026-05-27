# Unit Of Work Refactor

Current risk: `UnitOfWorkBehaviour<TRequest, TResponse>` is constrained to
`where TRequest : ICommand`, but current command types implement `IRequest<T>`
directly. That means the pipeline does not wrap most writes in one transaction.
Handlers then call `SaveChangesAsync` manually, sometimes multiple times.

## Option A: Introduce ICommand Properly

```csharp
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
```

Then update write commands:

```csharp
public class CreateMangaCommand : ICommand<string>
{
    ...
}
```

The UnitOfWork behaviour should target `ICommand<TResponse>`:

```csharp
public class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    ...
}
```

Finally, remove `SaveChangesAsync` calls from command handlers and let the
pipeline save once after the handler succeeds.

## Option B: Keep Manual Save

If you prefer not to change command interfaces, remove the pipeline behaviour
and make each handler responsible for exactly one `SaveChangesAsync` call. Avoid
DB writes before file writes unless you have a cleanup strategy for failed files.

## File And Database Consistency

For upload flows:

1. Validate all inputs first.
2. Store files with generated names.
3. Add entities referencing stored paths.
4. Save database changes once.
5. If DB save fails, delete newly stored files in a catch block.

