using NoteTakingApp.Domain.User;

namespace NoteTakingApp.Application.User
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserEntity> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, UserEntity user);
        Task UpdateAsync(CancellationToken cancellationToken, UserEntity user);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        Task<UserEntity> GetAsync(CancellationToken cancellationToken, string email);
    }
}