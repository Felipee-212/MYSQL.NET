var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int contador = 0;

app.MapGet("/contador", () =>
{
    return contador;
});

app.MapPost("/incrementar", () =>
{
    contador++;
    return contador;
});

app.MapPost("/reiniciar", () =>
{
    contador = 0;
    return contador;
});

app.Run();