using PetFamily.Application.Dtos;

namespace PetFamily.Application.Volunteers.UpdateRequisites;

public record UpdateRequisitesDto(IEnumerable<RequisiteDto> Requisites);
