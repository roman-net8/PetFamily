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

        var result = await service.CreateVolunteer(request, cancellationToken);
         
        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }

}
