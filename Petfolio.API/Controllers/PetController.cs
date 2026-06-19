using Microsoft.AspNetCore.Mvc;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterPetJson request)
    {
        // Business logic
        var response = new ResponseRegisterPetJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        return Created(string.Empty, response);
    }
}
