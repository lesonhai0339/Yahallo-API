# User Controller Authorization Refactor

Current risk: `UserController` has no controller-level `[Authorize]`, so all user
management endpoints are public unless each handler fully protects itself.

## Minimal Controller Shape

```csharp
using Microsoft.AspNetCore.Authorization;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("user/login")]
        public async Task<ActionResult<JsonResponse<LoginRespone>>> Login(...)
        {
            ...
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("user/create")]
        public async Task<ActionResult<JsonResponse<string>>> CreateUser(...)
        {
            ...
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("user/forgot-password")]
        public async Task<ActionResult<JsonResponse<string>>> ForgotPassword(...)
        {
            ...
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("user/get-all")]
        public async Task<ActionResult<JsonResponse<List<UserDto>>>> GetAll(...)
        {
            ...
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("user/get-all-deleted")]
        public async Task<ActionResult<JsonResponse<List<UserDto>>>> GetAllDeleted(...)
        {
            ...
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("user/restore")]
        public async Task<ActionResult<JsonResponse<string>>> RestoreUser(...)
        {
            ...
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("user/delete")]
        public async Task<ActionResult<JsonResponse<string>>> DeleteUser(...)
        {
            ...
        }
    }
}
```

## Handler-Level Follow-Up

For `change-password` and `update-user`, do not trust a user id supplied by the
request body. Resolve the current user from `ICurrentUserService.UserId`, unless
the caller has an admin policy.

