var builder = DistributedApplication.CreateBuilder(args);

// Use a connection string named "guitagent-db" instead of a Docker container
var db = builder.AddConnectionString("guitagent-db");

var api = builder.AddProject<Projects.Guitagent_API>("api")
    .WithReference(db);

builder.AddProject<Projects.Guitagent_Web>("web")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();

