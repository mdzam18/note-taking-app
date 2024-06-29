using NoteTakingApp.Domain.Note;

namespace NoteTakingApp.Domain.User
{
    public class UserEntity
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<NoteEntity> Notes { get; set;}

    }
}