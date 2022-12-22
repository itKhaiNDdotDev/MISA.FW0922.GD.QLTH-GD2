using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.BL.StudentBL;
using MISA.FW0922GD.QLTH.GD2.DL;
using MISA.FW0922GD.QLTH.GD2.DL.BaseDL;
using MISA.FW0922GD.QLTH.GD2.DL.StudentDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS Policy (Author: KhaiND - 21/12/2022)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Turn off Automatic Model State Validation (Author: KhaiND - 21/12/2022)
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped<IStudentDL, StudentDL>();
builder.Services.AddScoped<IStudentBL, StudentBL>();

// Lấy dữ liệu ConnectionString từ file appsettings.Development.json (Author: KhaiND - 21/12/2022)
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySql");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aply CORS Midlewares (Author: KhaiND - 21/12/2022)
app.UseCors("myAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
