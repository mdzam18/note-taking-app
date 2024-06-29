using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NoteTakingApp.Api.Infrastructure.Auth.JWT;
using NoteTakingApp.Application.User;

namespace NoteTakingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;


        public UserController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }

        [HttpGet]
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _userService.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<UserResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _userService.GetAsync(cancellationToken, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _userService.DeleteAsync(cancellationToken, id);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task Post(CancellationToken cancellationToken, UserCreateModel request)
        {
            await _userService.CreateAsync(cancellationToken, request);
        }

        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, UserRequestModel request)
        {
            await _userService.UpdateAsync(cancellationToken, request);
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<string> LogIn(UserLoginModel user, CancellationToken cancellation = default)
        {
            var result = await _userService.AuthenticationAsync(cancellation, user.Email, user.Password);

            return JWTHelper.GenerateSecurityToken(result, _options);
        }

    }
}