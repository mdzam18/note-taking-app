using Mapster;
using NoteTakingApp.Application.Exceptions;
using NoteTakingApp.Domain.User;

namespace NoteTakingApp.Application.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AuthenticationAsync(CancellationToken cancellationToken, string email, string password)
        {
            var result = await _repository.GetAsync(cancellationToken, email);

            if (result == null || !password.Equals(result.Password))
                throw new IncorrectEmailOrPasswordException("email or password is incorrect");

            return result.Username;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, UserCreateModel user)
        {
            var userToInsert = user.Adapt<UserEntity>();

            await _repository.CreateAsync(cancellationToken, userToInsert);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _repository.Exists(cancellationToken, id))
                throw new UserNotFoundException(id.ToString());

            await _repository.DeleteAsync(cancellationToken, id);
        }

        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null)
                throw new UserNotFoundException(id.ToString());
            else
                return result.Adapt<UserResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, UserRequestModel user)
        {
            if (!await _repository.Exists(cancellationToken, user.Id))
                throw new UserNotFoundException(user.Id.ToString());

            var userToUpdate = user.Adapt<UserEntity>();

            await _repository.UpdateAsync(cancellationToken, userToUpdate);
        }
    }
}
