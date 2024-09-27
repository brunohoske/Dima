using Dima.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionStr = builder //Registra a connection string
    .Configuration.GetConnectionString(name: "DefaultConnection") ?? string.Empty; //Utiliza o parametro criando em appsettings
                                                                                   //Caso não encontre a string ele vai como vazio

builder.Services.AddDbContext<AppDbContext>( // Registrando o DB contexto do EF 
    options =>
    {
        options.UseSqlServer();

    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomOperationIds(n => n.GroupName);
});
builder.Services.AddTransient<Handler>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/products", () => "Hello World!");
app.MapGet("/categories", () => "Hello World!");


app.MapPost("/v1/transactions", (Request request, Handler handler) => handler.Handle(request))
//Em suma é isso, você solicita um request, e usa o handle para enviar o response

//Metodos para documentação da API (repare que ele está ligado ao post acima)
.WithName("Transactions: Create")
.WithSummary("Cria uma nova transação")
.Produces<Response>();




app.MapPut("/categories", () => "Hello World!");
app.MapDelete("/categories", () => "Hello World!");


app.Run();

//Request

public class Request() // Oque é enviado
{

    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserID { get; set; } = string.Empty;
}


//Response

public class Response() // O que é recebido
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}


//Handler
public class Handler
{
    public Response Handle(Request request) // O que é executado
    {
        return new Response()
        {
            Id = 4,
            Title = request.Title
        };
    }
}