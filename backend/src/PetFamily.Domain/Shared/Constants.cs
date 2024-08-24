namespace PetFamily.Domain.Shared;

public class Constants
{
    public static class PetConst
    {
        public const int MAX_NAME_TEXT_LENGTH = 128;
        public const int MAX_TYPE_TEXT_LENGTH = 64;
        public const int MAX_DESCRIPTION_TEXT_LENGTH = 256;
        public const int MAX_BREED_TEXT_LENGTH = 32;
        public const int MAX_COLOR_TEXT_LENGTH = 32;
        public const int MAX_HEALTH_TEXT_LENGTH = 256;
        public const int MAX_ADDRESS_TEXT_LENGTH = 256;
        public const int MAX_OWNER_PHONE_TEXT_LENGTH = 16;
    }

    public static class PetPhotoConst
    {
        public const int MAX_PATH_TEXT_LENGTH = 256;
    }

    public static class VolunteerConst
    {
        public const int MAX_FIRST_NAME_TEXT_LENGTH = 32;
        public const int MAX_LAST_NAME_TEXT_LENGTH = 32;
        public const int MAX_EMAIL_TEXT_LENGTH = 128;
        public const int MAX_PHONE_TEXT_LENGTH = 16;
        public const int MAX_DESCRIPTION_TEXT_LENGTH = 256;
    }

    public static class SocialNetworkConst
    {
        public const int MAX_FIRST_NAME_TEXT_LENGTH = 32;
        public const int MAX_LAST_NAME_TEXT_LENGTH = 32;
        public const int MAX_LINK_TEXT_LENGTH = 512;
        public const int MAX_DESCRIPTION_TEXT_LENGTH = 256;
    }

    public static class RequisiteConst
    {
        public const int MAX_NAME_TEXT_LENGTH = 32;
        public const int MAX_DESCRIPTION_TEXT_LENGTH = 256;
    }
}
