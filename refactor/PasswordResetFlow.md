# Password Reset Refactor

Current risk: `ForgotPasswordCommandHandler` changes the user's password to a
6-character value and emails the password in plaintext.

## Safer Flow

1. `POST /user/forgot-password`
   - Accepts an email.
   - Always returns a generic success response.
   - If a matching active user exists, creates a random reset token.
   - Stores only a hash of that reset token with an expiry timestamp.
   - Sends a reset link containing the raw token.

2. `POST /user/reset-password`
   - Accepts `userId`, `token`, and `newPassword`.
   - Hashes the submitted token and compares it to the stored hash using a
     constant-time comparison.
   - Rejects expired or already-used tokens.
   - Updates password using the existing password hasher.
   - Marks the reset token as used.

## Token Entity Sketch

```csharp
public sealed class PasswordResetTokenEntity : BaseEntity
{
    public string UserId { get; set; } = default!;
    public string TokenHash { get; set; } = default!;
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime? UsedAtUtc { get; set; }
}
```

## Handler Pattern

```csharp
var rawToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
var tokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));

repository.Add(new PasswordResetTokenEntity
{
    UserId = user.Id,
    TokenHash = tokenHash,
    ExpiresAtUtc = DateTime.UtcNow.AddMinutes(30)
});

await unitOfWork.SaveChangesAsync(cancellationToken);
await emailService.SendPasswordResetLink(user.Email, user.Id, rawToken);
```

Do not reveal whether an email exists. Do not log the token. Do not include the
new password in email or logs.

