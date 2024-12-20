using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseSwagger();
    app.UseSwaggerUI();
}
//21:19 görüþelim


app.MapGet("/get", () => //default query params ?age=10  bunun yerine ../10
{
    return "Hello world!";
});

app.MapPost("/create", (CreateUserDto request) =>
{
    return "Created";
});

app.MapPut("/update", (UpdateUserDto request) =>
{
    return "Updated";
});

app.MapDelete("/delete", () =>
{
    return "Deleted";
});
app.Run();



// kodun okunaklýðý yüksek olmak zorundadýr
// iyi yazýlýmcý çok karmaþýk kod yazan deðil
// kodu okunabilendir


internal record CreateUserDto(
    string Name, int Age);

internal record UpdateUserDto(
    int Id, string Name, int Age);