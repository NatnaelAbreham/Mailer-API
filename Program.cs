using MailerApi.Models;
using MailerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
