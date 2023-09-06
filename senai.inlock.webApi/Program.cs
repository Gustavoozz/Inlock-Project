using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde está vindo (issuer)
        ValidIssuer = "senai.inlock.webApi",

        //Para onde está indo (audience)
        ValidAudience = "senai.inlock.webApi"
    };
});

//Adiciona o gerador do Swagger 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Inlock Jogos Tarde",
        Description = "API para gerenciamento de Jogos e Estudios - Sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Senai Informática - Turma Tarde",
            Url = new Uri("https://github.com/senai-desenvolvimento")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
