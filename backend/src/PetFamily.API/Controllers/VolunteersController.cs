using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Application.Volunteers.Delete;
using PetFamily.Application.Volunteers.UpdateMainInfo;
using PetFamily.Application.Volunteers.UpdateRequisites;
using PetFamily.Application.Volunteers.UpdateSocialNetworks;

namespace PetFamily.API.Controllers;

public class VolunteersController : ApplicationController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerCommand request,
        CancellationToken cancellationToken)
    {

        var result = await handler.CreateVolunteer(request, cancellationToken);

        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }


    [HttpPut("{id:guid}/main-info")]
    public async Task<ActionResult> UpdateMainInfo(
    [FromRoute] Guid id,
    [FromBody] UpdateMainInfoDto mainInfoDto,
    [FromServices] UpdateMainInfoHandler handler,
    //    [FromServices] IValidator<UpdateMainInfoRequest> validator,
    CancellationToken cancellationToken = default)
    {
        var request = new UpdateMainInfoRequest(id, mainInfoDto);

        /*      var validationResult = await validator.ValidateAsync(request, cancellationToken);
              if (validationResult.IsValid == false)
                  return validationResult.ToValidationErrorResponse();*/

        var result = await handler.Handle(request, cancellationToken); 
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }


    [HttpPut("{id:guid}/requisites")]
    public async Task<ActionResult> UpdateRequisites(
     [FromRoute] Guid id,
     [FromBody] UpdateRequisitesDto dto,
     [FromServices] UpdateRequisitesHandler handler, 
     CancellationToken cancellationToken = default)
    {
        var request = new UpdateRequisitesRequest(id, dto);
         
        var result = await handler.Handle(request, cancellationToken); 
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }


    [HttpPut("{id:guid}/social-networks")]
    public async Task<ActionResult> UpdateSocialNetworks(
    [FromRoute] Guid id,
    [FromBody] UpdateSocialNetworksDto dto,
    [FromServices] UpdateSocialNetworksHandler handler, 
    CancellationToken cancellationToken = default)
    {
        var request = new UpdateSocialNetworksRequest(id, dto);
         
        var result = await handler.Handle(request, cancellationToken); 
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
    [FromRoute] Guid id,
    [FromServices] DeleteVolunteerRequestHandler handler,
  //  [FromServices] DeleteVolunteerRequestValidator validator,
    CancellationToken cancellationToken = default)
    {
        var request = new DeleteVolunteerRequest(id);

      //  var validationResult = await validator.ValidateAsync(request, cancellationToken); 
    //    if (validationResult.IsValid == false)
      //      return validationResult.ToValidationErrorResponse();

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }
}
