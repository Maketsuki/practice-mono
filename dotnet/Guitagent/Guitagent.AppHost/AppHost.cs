var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume();

var db = postgres.AddDatabase("guitagent-db");

var api = builder.AddProject<Projects.Guitagent_API>("api")
    .WithReference(db);

builder.AddProject<Projects.Guitagent_Web>("web")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
