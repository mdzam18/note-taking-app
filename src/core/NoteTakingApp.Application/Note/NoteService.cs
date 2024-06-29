using Mapster;
using NoteTakingApp.Application.Exceptions;
using NoteTakingApp.Domain.Note;

namespace NoteTakingApp.Application.Note
{
    public class NoteService : INoteService
    {

        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, NoteRequestModel note)
        {
            var noteToInsert = note.Adapt<NoteEntity>();

            await _repository.CreateAsync(cancellationToken, noteToInsert);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _repository.Exists(cancellationToken, id))
                throw new NoteNotFoundException(id.ToString());

            await _repository.DeleteAsync(cancellationToken, id);
        }

        public async Task<List<NoteResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            return result.Adapt<List<NoteResponseModel>>();
        }

        public async Task<NoteResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null)
                throw new NoteNotFoundException(id.ToString());
            else
                return result.Adapt<NoteResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, NoteRequestModel note)
        {
            if (!await _repository.Exists(cancellationToken, note.Id))
                throw new NoteNotFoundException(note.Id.ToString());

            var noteToUpdate = note.Adapt<NoteEntity>();

            await _repository.UpdateAsync(cancellationToken, noteToUpdate);
        }
    }
}