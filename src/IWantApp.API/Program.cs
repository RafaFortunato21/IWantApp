using IWantApp.Application.Contracts;
using IWantApp.Application.Mappings;
using IWantApp.Application.Services;
using IWantApp.Infra.Data.Context;
using IWantApp.Infra.Data.Contracts;
using IWantApp.Infra.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using IWantApp.Application.Services.UserIdentity;


var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.MSSqlServer(

        context.Configuration["ConnectionStrings:DefaultConnection"],
            sinkOptions: new MSSqlServerSinkOptions()
            {
                AutoCreateSqlTable = true,
                TableName = "LogAPI"
            });
});


//Deny access bu default, to allow have to use [AllowAnonymous]
builder.Services.AddAuthorization(option =>
{
    option.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();

    option.AddPolicy("EmployeePolicy", p =>
    {
        p.RequireAuthenticatedUser()
        .RequireClaim("EmployeeCode", "002");
    });


});
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        //ValidateActor = true,
        ClockSkew = TimeSpan.Zero, //Tempo extra após a expiração do Token
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
        ValidAudience = builder.Configuration["JwtToken:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:Secretkey"]))
    };
});

builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:DefaultConnection"]);


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 3;
    }
)

.AddEntityFrameworkStores<ApplicationDbContext>();



// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddDbContext<ApplicationDbContext>(
//        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddScoped<ApplicationDbDapper>();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserIdentityService, UserIdentityService>();


builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));






builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();


app.UseExceptionHandler("/api/error");
//app.UseHsts();

//app.UseExceptionHandler("/api/error");
//app.UseStatusCodePagesWithReExecute("/api/error");


app.MapControllers();

app.Run();
