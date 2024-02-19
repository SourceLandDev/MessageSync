using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SourceLand.MessageSync.Utils;

public record Config(long ChatId, int MessageThreadId, int InfoThreadId, bool SyncMode)
{
    internal static readonly Lazy<Config?> Shared = new(() =>
    {
        string path = Path.Combine(Main.ContainerPath.Value!, "config.json");
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddJsonFile(path, true, true);
        return builder.Configuration.Get<Config>();
    });
}