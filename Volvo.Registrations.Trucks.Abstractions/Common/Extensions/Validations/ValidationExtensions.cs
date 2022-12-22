namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Extensions.Validations;

public static class ValidationExtensions
{
    public static bool IsValidName(this string @string, out string validatedName)
    {
        var isValid = !string.IsNullOrWhiteSpace(@string);
        validatedName = @string;
        return isValid;
    }

    public static bool IsValidGuid(this Guid guid, out Guid validatedGuid)
    {
        var isValid = guid != Guid.Empty;
        validatedGuid = guid;
        return isValid;
    }
}
