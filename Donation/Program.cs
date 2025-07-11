using System.Text;
using Donation;
using Donation.Data;
using Donation.Repository;
using Donation.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Donation.Models;
using Donation.ViewModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressMapClientErrors = true;
    });

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DonationCs");
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
 );

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ITrocaRepository, TrocaRepository>();

//MAPPER

var mapperConfig = new MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<UsuarioModel, LoginRequestVM>();
    c.CreateMap<LoginRequestVM, UsuarioModel>();

    c.CreateMap<LoginResponseVM, UsuarioModel>();
    c.CreateMap<UsuarioModel, LoginResponseVM>();

    c.CreateMap<UsuarioModel, UsuarioResponseVM>();
    c.CreateMap<UsuarioResponseVM, UsuarioModel>();

    c.CreateMap<UsuarioModel, UsuarioRequestVM>();
    c.CreateMap<UsuarioRequestVM, UsuarioModel>();
    c.CreateMap<UsuarioRequestVM, UsuarioResponseVM>();

    c.CreateMap<TrocaRequestVM, TrocaModel>();

    c.CreateMap<TrocaModel, TrocaResponseVM>();
    c.CreateMap<ProdutoModel, ProdutoResponseVM>();

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


//AUTHENTICATION

bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
{
    if (expires != null)
    {
        return expires > DateTime.UtcNow;
    }
    return false;
}

var key = Encoding.UTF8.GetBytes(Settings.SECRET_TOKEN);

builder.Services.AddAuthentication(
    a =>
    {
        a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(
        opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "fiap",
                IssuerSigningKey = new SymmetricSecurityKey(key),
                //LifetimeValidator = ...
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true
            };
        }
    );
//AUTHENTICATION

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
