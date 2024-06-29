namespace NoteTakingApp.Application.Exceptions
{
    public class NoteNotFoundException : Exception
    {

        public string Code = "NoteNotFound";

        public NoteNotFoundException(string message) : base(message) { }

    }
}