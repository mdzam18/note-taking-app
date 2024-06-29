namespace NoteTakingApp.Application.User
{
    public interface IUserService
    {
        Task<string> AuthenticationAsync(CancellationToken cancellationToken, string email, string password);
        Task CreateAsync(CancellationToken cancellationToken, UserCreateModel user);
        Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, UserRequestModel user);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
