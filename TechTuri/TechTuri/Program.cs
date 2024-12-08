using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TechTuri.Mappers;
using TechTuri.Model;
using TechTuri.Services;
using Fleck;
using TechTuri.WebSocket;

//var server = new WebSocketServer("ws://0.0.0.0:9876");

//server.Start(ws =>
//{
//    ws.OnMessage = message =>
//    {
//        Console.WriteLine(message);
//    };
//});


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddWebSocketManager();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });



builder.Services.AddSqlite<DataContext>(builder.Configuration.GetConnectionString("DefaultConnection"));



var app = builder.Build();

app.UseWebSockets();

var chatWs = app.Services.GetRequiredService<chatRoomHandler>();

app.MapWebSocketManager("/ws", chatWs);

//app.Map("/ws", builder =>
//{
//    builder.UseMiddleware<WebSocketManagerMiddleware>();
//});

app.UseCors(x => x
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
