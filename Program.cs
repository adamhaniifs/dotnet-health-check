using HealthCheck.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000", "http://0.0.0.0:50051");

builder.Services.AddGrpc();
var app = builder.Build();

// REST Endpoints
app.MapGet("/", () => Results.Json(new { message = "devops dotnet 7 health-check" }));
app.MapGet("/health-check", () => Results.Json(new
{
    status = "up",
    service = "dotnet 7 devops health check"
}));
app.MapGet("/version", () =>
{
    var version = Environment.GetEnvironmentVariable("VERSION") ?? "no-version";
    return Results.Json(new { version });
});

// gRPC Endpoint
app.MapGrpcService<GreeterService>();
app.MapGet("/grpc", () => "This server hosts gRPC endpoints on port 50051.");

app.Run();
