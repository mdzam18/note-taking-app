using NoteTakingApp.Application.Note;
using NoteTakingApp.Application.User;
using NoteTakingApp.Infrastructure.User;
using NoteTakingApp.Infrastructure.Note;


namespace NoteTakingApp.Api.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INoteService, NoteService>();
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
        }

    }
}