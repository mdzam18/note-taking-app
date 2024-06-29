namespace NoteTakingApp.Application.Note
{
    public interface INoteService
    {
        Task CreateAsync(CancellationToken cancellationToken, NoteRequestModel user);
        Task<List<NoteResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<NoteResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, NoteRequestModel note);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}