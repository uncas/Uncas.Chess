using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Uncas.Chess
{
    public static class Bootstrapper
    {
        public static void ConfigureChess(this IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.Scan(
                scan => scan
                    .FromAssemblyOf<ChessSimulator>()
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .AsSelf());
        }
    }
}