using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.Volunteers.Create;

namespace PetFamily.API.Controllers;

public class VolunteersController : ApplicationController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerService service,
        [FromBody] CreateVolunteerCommand request,
        CancellationToken cancellationToken)
    {
        var result = await service.Create(request, cancellationToken);

        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }

        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }

}
