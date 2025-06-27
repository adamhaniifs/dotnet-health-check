using Grpc.Core;
using HealthCheck.Grpc;

namespace HealthCheck.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<VersionReply> GetVersion(VersionRequest request, ServerCallContext context)
    {
        var version = Environment.GetEnvironmentVariable("VERSION") ?? "no-version";
        return Task.FromResult(new VersionReply
        {
            Version = version
        });
    }
}
