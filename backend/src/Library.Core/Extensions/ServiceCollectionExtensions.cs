
namespace Library.Core.Extensions;

using Library.Core.Domain.Repositories;
using Library.Core.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IBookService, BookService>();

        return services;
    }
}

