# Yahallo API Refactor Notes

This folder contains isolated refactor proposals for the issues found during review.
They are intentionally kept outside the active projects so the current solution still
builds while you review and apply the changes in smaller commits.

## Recommended Apply Order

1. `SecureApplicationSecurityConfiguration.cs`
   - Enables issuer and audience validation.
   - Fails fast when required JWT settings are missing.
   - Adds clear fallback authorization policy.

2. `SecureJwtService.cs`
   - Uses configuration instead of repeatedly loading `.env`.
   - Emits consistent UTC token expiry.
   - Includes user level claim when needed by policies.

3. `UserControllerAuthorization.md`
   - Shows the minimal controller-level authorization changes.
   - Keeps only login, create, forgot-password, confirm-email style routes public.

4. `SafeFileStorage.cs`
   - Replaces direct use of uploaded `FileName`.
   - Validates size and extension.
   - Enforces writes inside a known storage root.

5. `SafeLoggingBehaviours.cs`
   - Logs request type and user id without serializing full request bodies.
   - Prevents passwords, tokens, uploaded files, and PII from being written to logs.

6. `PasswordResetFlow.md`
   - Replaces plaintext temporary-password reset with a token flow.

7. `UnitOfWorkRefactor.md`
   - Explains why the current UnitOfWork pipeline is not applied and how to fix it.

## Current Verification Baseline

- `dotnet build YAHALLO.sln --no-restore`: succeeds with warnings.
- `dotnet test YAHALLO.sln --no-build`: succeeds, but current tests are smoke-only.

