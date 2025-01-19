using MicroserviceTemplate.Common.Config;
using MicroserviceTemplate.Data;
using MicroserviceTemplate.Data.Repositories;
using MicroserviceTemplate.Managers;
using MicroserviceTemplate.Managers.ApiManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

RegisterManagers(builder.Services);
RegisterRepositories(builder.Services);

//If user validation middleware is in use, contextData should be set to service
//builder.Services.AddScoped<ContextData>();
//If endpoints middleware is in use, EndpointsContextData should be set to services
//builder.Services.AddScoped<EndpointsContextData>();

builder.Services.AddSingleton(builder.Configuration.GetSection("ApplicationConfig").Get<ApplicationConfig>());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string projectname = Assembly.GetExecutingAssembly().GetName().Name;
//XML name of domain (for DTOs)
string projectdomainxmlname = projectname + ".Domain" + ".xml";
//XML name of main project (for controllers and actions)
string projectxmlName = projectname + ".xml";
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//On build generate swagger documentation files. If documentation is not needed or there's a problem, then comment this part away.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "MicroserviceTemplate",
        Description = "API v1"
    });

    var filePath = Path.Combine(AppContext.BaseDirectory, projectxmlName);
    c.IncludeXmlComments(filePath);

    var filePath2 = Path.Combine(AppContext.BaseDirectory, projectdomainxmlname);
    c.IncludeXmlComments(filePath2);
});

//Enabling quartz if needed. If quartz is not needed the quartz package can be removed.
//builder.Services.AddQuartz(q =>
//{
//    q.UseMicrosoftDependencyInjectionJobFactory();

//    var microserviceTemplateJob = new JobKey("MicroserviceTemplateJob");
//    q.AddJob<MicroserviceTemplateJob>(opts => opts.WithIdentity(microserviceTemplateJob));
//    q.AddTrigger(opts => opts
//        .ForJob(microserviceTemplateJob)
//        .WithIdentity("MicroserviceTemplateJob-trigger")
//        .WithSimpleSchedule(x => x
//            .WithIntervalInSeconds(5)
//            .RepeatForever()));
//});

//builder.Services.AddQuartzHostedService(
//    q => q.WaitForJobsToComplete = true);

builder.Logging.AddLog4Net();

//Database setup. Data project needs Npgsql.EntityFrameworkCore.PostgreSQL
builder.Services.AddDbContext<MicroserviceTemplateDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Connection"),
        npgsqlOptions => npgsqlOptions.EnableRetryOnFailure());
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Apply middleware that will change exceptions to status codes.
//app.UseMiddleware<ExceptionMiddleware>();
//Apply middleware that will enable user validation
//app.UseMiddleware<UserValidationMiddleware>();
//Apply middleware that will get endpoints from given url from headers
//app.UseMiddleware<EndpointsMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();

static void RegisterRepositories(IServiceCollection services)
{
    Assembly repositoryAssembly = typeof(MicroserviceTemplateRepository).Assembly;
    //IF THE BELOW DOESN'T FIND ANY REGISTRATIONS TRY THIS INSTEAD
    //var repositoryRegistrations2 = repositoryAssembly.GetExportedTypes().Where(type =>
    //type.Namespace == "MicroserviceTemplate.Data.Repositories"
    //&& type.GetInterfaces().Any()
    //&& !type.IsGenericType
    //&& !type.IsInterface).Select(type => new { Service = type.GetInterfaces().Single(i => !i.IsGenericType && !i.Name.StartsWith("IRepository")), Implementation = type }).ToList();

    var repositoryRegistrations =
        from type in repositoryAssembly.GetExportedTypes()
        where type.Namespace == "MicroserviceTemplate.Data.Repositories"
        where type.GetInterfaces().Any()
            && !type.IsGenericType
        select new { Service = type.GetInterfaces().Single(i => !i.Name.StartsWith("IRepository")), Implementation = type };

    foreach (var reg in repositoryRegistrations)
    {
        services.AddScoped(reg.Service, reg.Implementation);
    }
}

static void RegisterManagers(IServiceCollection services)
{
    Assembly microserviceTemplate = typeof(IMicroserviceTemplateManager).Assembly;
    Assembly apiManagerAssembly = typeof(ApiManager).Assembly;
    Assembly userManagerAssembly = typeof(UserManagerAPIManager).Assembly;

    RegisterAssemblyManager(services, microserviceTemplate, "MicroserviceTemplate.Managers.MicroserviceTemplate");
    RegisterAssemblyManager(services, apiManagerAssembly, "MicroserviceTemplate.Managers.ApiManager");
    RegisterAssemblyManager(services, userManagerAssembly, "ProcurementPublicAPI.Managers.UserManagerApi");
}

static void RegisterAssemblyManager(IServiceCollection services, Assembly managerAssembly, string assemblyNamespace)
{
    var managerRegistrations =
        from type in managerAssembly.GetExportedTypes()
        where type.Namespace == assemblyNamespace
        where type.GetInterfaces().Any()
              && !type.IsGenericType
              && !type.IsInterface
        select new { Service = type.GetInterfaces().Single(i => !i.IsGenericType), Implementation = type };

    foreach (var reg in managerRegistrations)
    {
        services.AddScoped(reg.Service, reg.Implementation);
    }
}