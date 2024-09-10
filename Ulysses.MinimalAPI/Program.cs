using Ulysses.MinimalAPI.Model;

var builder = WebApplication.CreateBuilder(args);

//habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


//instanciando o repositório de pessoas
var repository = new PessoaRepository(true);

//ativando o swagger
app.UseSwagger();

//Endpoints da solução
app.MapGet("/", () => "Hello World!");

app.MapGet("/ListaPessoas", () =>
{
    return repository.SelecionarPessoas();
});

//Buscar pessoa pelo CPF.
app.MapGet("/ListaPessoas/{cpf}", (string cpf) => {
    return repository.SelecionarPessoa(cpf);
});

//Adicionar pessoa.
app.MapPost("/ListaPessoas/adicionar", (Pessoa pessoa) => {
    return repository.AdicionarPessoas(pessoa);
});

//Atualizar pessoa.
app.MapPut("/ListaPessoas/atualizar", (Pessoa pessoa) => {
    return repository.AtualizarPessoas(pessoa);
});

//Remover pessoa.
app.MapDelete("/ListaPessoas/remover", (string cpf) => {
    return repository.RemoverPessoas(cpf);
});

// Ativando a interface Swagger
app.UseSwaggerUI();


app.Run();
