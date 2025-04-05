using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
// This attribute is used to specify that the controller will respond to HTTP requests
// We use the plural in the route to follow the RESTful convention
public class BaseApiController : ControllerBase
{
}
