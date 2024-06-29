using NoteTakingApp.Domain.Note;

namespace NoteTakingApp.Application.Note
{
    public interface INoteRepository
    {
        Task<List<NoteEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<NoteEntity> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, NoteEntity note);
        Task UpdateAsync(CancellationToken cancellationToken, NoteEntity note);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
    }
}