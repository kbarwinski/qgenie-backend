using QGenieBackend.Contexts;
using QGenieBackend.Handlers;
using QGenieBackend.Repositories.Candidates;
using QGenieBackend.Repositories.Interviews;
using QGenieBackend.Repositories.Messages;
using QGenieBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load();

builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddSingleton<ICandidateRepository, CandidateRepository>();
builder.Services.AddSingleton<IInterviewRepository, InterviewRepository>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();

builder.Services.AddSingleton<ILLMService, OpenAILLMService>();
builder.Services.AddScoped<IQueryGeneratorService, QueryGeneratorService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
