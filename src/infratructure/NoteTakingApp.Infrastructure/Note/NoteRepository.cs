using NoteTakingApp.Application.Note;
using NoteTakingApp.Domain.Note;
using NoteTakingApp.Persistence.Context;

namespace NoteTakingApp.Infrastructure.Note
{
    public class NoteRepository : BaseRepository<NoteEntity>, INoteRepository
    {
        public NoteRepository(NoteTakingAppContext context) : base(context)
        {

        }

        public async Task<NoteEntity> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }

        public async Task<List<NoteEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, NoteEntity note)
        {
            await base.AddAsync(cancellationToken, note);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, NoteEntity note)
        {
            await base.UpdateAsync(cancellationToken, note);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }

    }
}
