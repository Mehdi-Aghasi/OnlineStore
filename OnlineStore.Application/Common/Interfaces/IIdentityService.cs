namespace OnlineStore.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool IsSuccess, string UserId, string Error)> RegisterAsync(string email, string password, string firstName, string lastName);

        Task<(bool IsSuccess, string Token, string Error)> LoginAsync(string email, string password);
    }
}
