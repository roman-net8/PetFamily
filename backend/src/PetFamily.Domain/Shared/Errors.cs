namespace PetFamily.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("Invalid.input", $"{label} is invalid");
        }

        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $"for Id:{id}";
            return Error.NotFound("Record.not.found", $"record not found {forId}");
        }

        public static Error Null(string? name = null)
        {
            var label = name ?? "value";
            return Error.Null("Null.entity", $"{label} is null");
        }

        public static Error ValueIsEmpty(string? name = null)
        {
            var label = name == null ? "" : " " + name + " ";
            return Error.Validation("Invalid.length", $"invalid{label}length");
        }
    }

    public static class VolunteerError
    {
        public static Error AlreadyExists()
        {
            return Error.Validation("Record.already.exist", $"Volunteer already exist");
        }
    }
}