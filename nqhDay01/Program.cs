var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! - Nguyễn Quang Huy - 2210900105 ");

app.Run();
