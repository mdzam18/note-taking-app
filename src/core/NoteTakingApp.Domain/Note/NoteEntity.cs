using NoteTakingApp.Domain.User;

namespace NoteTakingApp.Domain.Note
{
    public class NoteEntity
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsPrivate { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

    }
}