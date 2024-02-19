using Hosihikari.PluginManagement;
using Microsoft.Extensions.Logging;
using SourceLand.MessageSync;
using System.Reflection;

[assembly: EntryPoint<Main>]

namespace SourceLand.MessageSync;

public sealed class Main : IEntryPoint
{
    internal static readonly Lazy<string?> ContainerPath;
    private static readonly Lazy<ILogger> s_logger;

    static Main()
    {
        ContainerPath = new(() =>
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string location = currentAssembly.Location;
            return Path.GetDirectoryName(location);
        });
        s_logger = new(() =>
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            return factory.CreateLogger(nameof(Qiao));
        });
    }

    internal static ILogger Logger => s_logger.Value;

    public void Initialize(AssemblyPlugin _)
    {
    }
}