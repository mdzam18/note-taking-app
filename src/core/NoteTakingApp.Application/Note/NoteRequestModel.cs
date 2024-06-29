namespace NoteTakingApp.Application.Note
{
    public class NoteRequestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }
    }
}