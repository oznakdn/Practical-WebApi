using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyBookStore.API.Data;
using MyBookStore.API.Models;
using MyBookStore.API.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

//SqlServer tanýmlandý
builder.Services.AddDbContext<MyBookStoreContext>(options=>options.UseSqlServer("server=DESKTOP-9DAI51M;Database=MyBookStoreAPI;Integrated Security=true"));
//Repositoriler için Dependency Injection eklendi
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
//Automapper eklendi
builder.Services.AddAutoMapper(typeof(Program));
//Api'yi bir uygulamanýn sunucusunda kullanmak için ekledik
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//Kullanýcý giriþi için Identity'yi ekliyoruz.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
AddEntityFrameworkStores<MyBookStoreContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ValidIssuer"]))
    };

});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(); // AddCors servis eklediðimizden bunu da ekliyoruz.
app.UseAuthentication(); // Authorizasyon için ekledik.

app.UseAuthorization();

app.MapControllers();

app.Run();
