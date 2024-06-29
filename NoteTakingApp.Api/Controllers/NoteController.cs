using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NoteTakingApp.Api.Infrastructure.Auth.JWT;
using NoteTakingApp.Application.Note;

namespace NoteTakingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IOptions<JWTConfiguration> _options;


        public NoteController(INoteService noteService, IOptions<JWTConfiguration> options)
        {
            _noteService = noteService;
            _options = options;
        }

        [HttpGet]
        public async Task<List<NoteResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _noteService.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<NoteResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _noteService.GetAsync(cancellationToken, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _noteService.DeleteAsync(cancellationToken, id);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task Post(CancellationToken cancellationToken, NoteRequestModel request)
        {
            await _noteService.CreateAsync(cancellationToken, request);
        }

        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, NoteRequestModel request)
        {
            await _noteService.UpdateAsync(cancellationToken, request);
        }

    }
}