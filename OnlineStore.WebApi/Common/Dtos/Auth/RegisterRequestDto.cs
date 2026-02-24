namespace OnlineStore.WebApi.Common.Dtos.Auth
{
    public record RegisterRequestDto(
        string Email,
        string Password,
        string FirstName,
        string LastName
    );
}
