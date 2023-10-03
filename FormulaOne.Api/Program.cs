using FormulaOne.Api.Modules.Feature;
using FormulaOne.Api.Modules.Swagger;
using FormulaOne.Api.Modules.Injection;
using FormulaOne.Api.Modules.Authentication;
using FormulaOne.Presistence;
using FormulaOne.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("policyApiFormulaOne");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
