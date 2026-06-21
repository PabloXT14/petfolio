using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var useCase = new RegisterPetUseCase();

        var response = useCase.Execute(request);
        
        return Created(string.Empty, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();
        
        var response = useCase.Execute();
        
        if (response.Pets.Count == 0)
        {
            return NoContent();
        }
        
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var useCase = new GetPetByIdUseCase();
        
            var response = useCase.Execute(id);
        
            return Ok(response);
        }
        catch (Exception error)
        {
            return NotFound(new ResponseErrorsJson
            {
                Errors = [error.Message]
            });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            var useCase = new DeletePetUseCase();
        
            useCase.Execute(id);
        
            return NoContent();
        }
        catch (Exception error)
        {
            return NotFound(new ResponseErrorsJson
            {
                Errors = [error.Message]
            });
        }
    }
}
