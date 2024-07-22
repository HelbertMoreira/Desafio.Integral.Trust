using Desafio.Integral.Trust.Core;
using Desafio.Integral.Trust.Core.Common.Api;
using Desafio.Integral.Trust.Core.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();

app.Run();
