using NoteTakingApp.Application.User;
using NoteTakingApp.Domain.User;
using NoteTakingApp.Persistence.Context;

namespace NoteTakingApp.Infrastructure.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(NoteTakingAppContext context) : base(context)
        {

        }

        public async Task<UserEntity> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }

        public async Task<List<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, UserEntity user)
        {
            await base.AddAsync(cancellationToken, user);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, UserEntity user)
        {
            await base.UpdateAsync(cancellationToken, user);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }

        public async Task<UserEntity> GetAsync(CancellationToken cancellationToken, string email)
        {
            return await base.GetAsync(cancellationToken, x => x.Email == email);
        }
    }
}
