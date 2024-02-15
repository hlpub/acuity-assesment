using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class ApiControllerBase : ControllerBase
{
}